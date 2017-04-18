using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Sie;
using Microsoft.Azure.Documents;

namespace PlayGround.Common.Sie.Transaction
{
    public class ByDimension: Resource
    {
        public string DimensionKey { get; set; }
        public List<GrouppedAccount> Transactions { get; set; }

        public ByDimension()
        {
            this.Transactions = new List<GrouppedAccount>();
        }
        public ByDimension(string key, List<GrouppedAccount> transactions )
        {
            this.DimensionKey = key;
            this.Transactions = transactions;
        }

    }
}
