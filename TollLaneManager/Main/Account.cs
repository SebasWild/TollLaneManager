using AutomatedRoadTollingSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedRoadTollingSystem
{
    public class Account
    {
        private int id { get; set; }
        private decimal balance { get; set; }
        public AccountHolder accountHolder { get; set; }
        private Vehicle vehicle { get; set; }

        public Account()
        {
            // New Account
        }
        public Account(int id, decimal balance)
        {
            this.id = id;
            this.balance = balance;
        }

        public Account(AccountHolder accountHolder, Vehicle vehicle)
        {
            this.accountHolder = accountHolder;
            this.vehicle = vehicle;
            this.balance = 0;
        }


        /// <summary>
        /// Subtracts specified ammount of funds from the account.
        /// * NOTE: this can be negitive this means the customer ows the company money.
        /// </summary>
        /// <param name="fundsToSub">How much the cusomter is being billed</param>
        /// <returns>The current balance of the account</returns>
        public decimal subtractFunds(decimal fundsToSub)
        {
            this.balance -= fundsToSub;
            return this.balance;
        }


        public String getPlate()
        {
            return DBgenerator.getPlateFromAccountID(this.id);
        }
    }
}
