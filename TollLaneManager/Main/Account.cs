using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollLaneManager
{
    public class Account
    {
        private decimal funds;
        private AccountHolder accountHolder;
        private Vehicle vehicle;
        private List<Transaction> transactions;

        public Account()
        {
            // New Account
        }

        public Account(AccountHolder accountHolder, Vehicle vehicle)
        {
            this.accountHolder = accountHolder;
            this.vehicle = vehicle;
            this.transactions = new List<Transaction>();
            this.funds = 0;
        }

        public decimal addFunds(decimal fundsToAdd)
        {
            this.funds += fundsToAdd;
            this.transactions.Add(new Transaction(fundsToAdd));
            return this.funds;
        }

        public decimal subtractFunds(decimal fundsToSub)
        {
            this.funds -= fundsToSub;
            //this.transactions.Add(new Transaction(-fundsToAdd)); // What is this supposed to do?
            return this.funds;
        }
        public String getPlate()
        {
            return this.vehicle.getPlate();
        }
    }
}
