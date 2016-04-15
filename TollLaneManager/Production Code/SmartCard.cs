using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollLaneManager
{
    public class SmartCard
    {
        String serialNum;
        Account account;
        public SmartCard(String num, Account account)
        {
            this.serialNum = num;
            this.account = account;
        }
        public Account getAccount()
        {
            return this.account;
        }
        public String getSerialNum()
        {
            return this.serialNum;
        }
    }
}
