using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollLaneManager
{
    public class Transaction
    {
        private static int transactionCount = 0;
        private int transactionNum;
        private decimal amountCharged;
        private DateTime timestamp;

        public Transaction(decimal amountCharged)
        {
            this.transactionNum = transactionCount++;
            this.timestamp = DateTime.Now();
            this.amountCharged = amountCharged;
        }
    }
}
