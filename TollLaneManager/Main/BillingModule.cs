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
	public static class BillingModule
	{

		/// <summary>
        ///     Bill the person based on the plate number
        /// </summary>
        /// <param name="plateNo"></param>
        /// <param name="fee"></param>
        public static String payTollViaPlate(String plateNo, decimal fee) {
            String rtn = "";
            if (plateNo != null) {

                try {
                    // bill the person who owns the liscense plate
                    rtn = DBActions.createTransactionFromPlate(plateNo, fee);

                }
                catch (Exception e) {
                    Console.WriteLine("ERROR IN payTollViaPlate()" + e.Message);
                }
            }
            return rtn;
		}

        /// <summary>
        ///     Bill the person based on the account id
        /// </summary>
        /// <param name="fee"></param>
        /// <param name="accountID"></param>
        public static String payTollViaAccountID(decimal fee, int accountID = -1)
        {
            String rtn = "";
            if (accountID != -1)
            {
                try
                {
                    // bill the person who owns the liscense plate
                  rtn = DBActions.createTransactionFromID(accountID, fee);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR IN payTollViaAccountID()" + e.Message);
                }
            }
            return rtn;
        }
    }
}