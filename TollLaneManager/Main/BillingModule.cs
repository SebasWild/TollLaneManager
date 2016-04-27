using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace AutomatedRoadTollingSystem
{

    /// <summary>
    ///     This module is used to bill each car that passes through the tolling system either directly though the drivers smart card (SRS Functional Requirements 4.2) 
    ///     or indirectly through the driver's license plate number (SRS Functional Requirements 4.3).
    /// </summary>
    public class BillingModule
	{
        SQLiteConnection m_dbConnection;//Connection to the DB instance
        public List<SmartCard> smartcards;
        public List<Account> accounts;

        public BillingModule()
        {
            m_dbConnection = new SQLiteConnection("Data Source = TollLaneManager.db");      //Path to our DB. (We would still need to open it to access DB)
        }

        /// <summary>
        /// Attempts to bill the account with the corresponding account number/license plate.
        /// 
        /// I am assuming that the smart card returns an account number...
        /// Note the optional parameter accountno. 
        /// You must supply at least a plate # for this to work.
        /// </summary>
        /// <param name="plateNo">plate number</param>
        /// <param name="accountno">account number</param>
        /// <param name="fee">How much to charge the dude</param>
        /// <returns>Account after the toll has been charged</returns>
        public async Task<Account> payToll(String plateNo, decimal fee, int accountno = -1) {
            if (plateNo == null) throw new ArgumentNullException("Plate # is null!");
            try
            {
                Account target;
                if (accountno != -1) target = await getAccountByID(accountno); else target = await getAccountByPlateNo(plateNo);
                if (target == null) billNonAccountHolder(plateNo, fee);
                try
                {
                    target.subtractFunds(fee);
                    return target;
                }
                catch (Exception e)
                {
                    throw new NotImplementedException("We have to implement billing someone with no funds left over!");
                }
            }
            catch(Exception e)
            {
                //Some DB Exception occured...
            }
            return null;
        }
        private async Task<Account> getAccountByID(int accountno)
        {
            await m_dbConnection.OpenAsync();
            string query = @"SELECT * FROM account WHERE id ='" + accountno + "';";     //The SQL query to run
            SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);           //Create the command using the connection and query
            var result = await command.ExecuteReaderAsync();            //await the result.
            if (result.HasRows)      //We actually got a result back, Account IDs are unique so there should always be one.
            {
                //We should only ever get one row, as we are querying using a primary key.
                while(result.Read())
                {
                    return new Account((int)result["id"], (decimal)result["balance"]);      //Casting may not work...
                }
                return null;    //make compiler happy.
            }
            else                    //No account was returned, return null
            {
                return null;       
            }
        }
        private async Task<Account> getAccountByPlateNo(String plateNo)
        {
            await m_dbConnection.OpenAsync();
            string query = @"SELECT * FROM register WHERE plateNo ='" + plateNo + "';";     //The SQL query to run
            SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);           //Create the command using the connection and query
            var result = await command.ExecuteReaderAsync();            //await the result.
            if (result.HasRows)
            {
                //We've got a hit on a plate number tied to an account.
                //Again, this should only run once as I am assuming plates are unique...
                while (result.Read())
                {
                    return await getAccountByID((int)result["id"]);
                }
            }
            return null;        //If we get here we no account for the plate number was found - gotta bill with snail mail.
        }
        /// <summary>
        /// Creates a txt file that saves 
        /// necessary information needed to send license plate info to
        /// third party for billing
        /// </summary>
        /// <param name="plateNo">plate number</param>
        /// <param name="fee">How much to charge the dude</param>
        /// <returns></returns>
        private void billNonAccountHolder(String plateNo,decimal fee)
        {
            String fileName = "test1.txt";  //TODO add transaction number here
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\TEMP\\" + fileName, true);
            file.WriteLine("Plate Number: " + plateNo);
            file.WriteLine("Transaction Number: "); //TODO add transaction number here
            file.WriteLine("Toll Amount: ", fee);
            file.Close();
        }
    
	}
}