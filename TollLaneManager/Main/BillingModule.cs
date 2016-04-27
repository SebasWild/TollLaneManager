using AutomatedRoadTollingSystem.Common;
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
		SQLiteConnection conn = DBgenerator.conn; //connection to the DB instance
		public List<SmartCard> smartcards;
		public List<Account> accounts;

		public BillingModule()
		{
			
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
		public Account payToll(String plateNo, decimal fee, int accountno = -1) {

            Account target = new Account();

            if (plateNo == null) {
                throw new ArgumentNullException("Plate # is null!");
            }

			try
			{
				
				if (accountno != -1) {
					target = DBgenerator.getAccountByID(accountno);
				} else {
					target = DBgenerator.getAccountByPlateNo(plateNo);
				}
				
				// bill the person who owns the liscense plate
				if (target == null) {                   
					billNonAccountHolder(plateNo, fee);
				} else {                   
					target.subtractFunds(fee); 
				}   														  
				            
			}
            catch (Exception e) {

                // Log the error message in the database
				//DBgenerator.createDBLog(e.Message); 
			}

			return target;
		}


		/// <summary>
		///     Bills non account holder and creates a transaction based off of the liscense plate
		/// </summary>
		/// <param name="plateNo">Plate number of the drivers car</param>
		/// <param name="fee"> How much to charge the driver</param>
		/// <returns></returns>
		private void billNonAccountHolder(String plateNo, decimal fee)
		{
            DBgenerator.createTransaction(plateNo, fee);
		}
	}
}