using AutomatedRoadTollingSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedRoadTollingSystem
{
    [System.Obsolete("Consider using DBActions to retreive account information from the database.")]
    public class Account
    {
        public int id { get; set; }
        public decimal balance { get; set; }
        public AccountHolder accountHolder { get; set; }
        public Vehicle vehicle { get; set; }

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
    }
}
