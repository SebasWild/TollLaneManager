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
 
        public Account(AccountHolder accountHolder, Vehicle vehicle)
        {
            this.accountHolder = accountHolder;
            this.vehicle = vehicle;
            this.transactions = new List<Transaction>();
            this.funds = 0;
        }
        public decimal addFunds(decimal fundsToAdd)
        {
            //stub
            return this.funds;
        }
        public decimal subtractFunds(decimal fundsToSub)
        {
            //stub
            return this.funds;
        }
    }
}
