using Common.Sie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Common.Sie.Transaction
{
    public class GrouppedTransactions
    {
        public ByDimension Transactions { get; set; }

        public GrouppedTransactions()
        {
            this.Transactions = new ByDimension();
        }
        public void Add(SieVoucherRow transaction)
        {
            this.Transactions.Add(transaction);
        }
    }


}
