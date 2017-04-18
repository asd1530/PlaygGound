using Common.Sie;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Common.Sie.Transaction
{
    public class GrouppedTransactions : Resource
    {
        public List<SieVoucherRow> Transactions { get; set; }

        public GrouppedTransactions()
        {
            this.Transactions = new List<SieVoucherRow>();
        }
        public void Add(SieVoucherRow transaction)
        {
            this.Transactions.Add(transaction);
        }
    }


}
