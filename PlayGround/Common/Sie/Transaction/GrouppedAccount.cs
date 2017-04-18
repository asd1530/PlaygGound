using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Common.Sie.Transaction
{
    public class GrouppedAccount
    {
        public GrouppedAccount()
        {
            this.Amounts = new Dictionary <string,decimal?>();
        }
        public string AccountNumber { get; set; }
        public Dictionary<string,decimal?> Amounts { get; set; }
    }
}
