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
        private AccountHolder accountHolder { get; set; }
        private Vehicle vehicle { get; set; }
        private List<Transaction> transactions { get; set; }     //Why are we tracking this?

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
            this.transactions = new List<Transaction>();
            this.balance = 0;
        }
        //I don't think it is within the scope of this app to do anything besides remove funds...
        public decimal addFunds(decimal fundsToAdd)
        {
            this.balance += fundsToAdd;
            //this.transactions.Add(new Transaction(fundsToAdd));
            return this.balance;
        }

        public decimal subtractFunds(decimal fundsToSub)
        {
            this.balance -= fundsToSub;
            if (balance < fundsToSub) throw new Exception("Not enough funds!");
            //this.transactions.Add(new Transaction(-fundsToAdd)); // What is this supposed to do?
            return this.balance;
        }
        public String getPlate()
        {
            return this.vehicle.getPlate();
        }
    }
}
