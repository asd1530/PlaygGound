using Common.Sie;
using System.Collections.Generic;

namespace PlayGround.Common.Sie.Transaction
{
    public class ByAccount
    {
        public string Account { get; set; }
        public ByDateMonth Transactions { get; set; }

        public ByAccount()
        {
            this.Transactions = new ByDateMonth();
        }

        public void Add(SieVoucherRow transaction)
        {
            this.Account = transaction.Account.Number;
            this.Transactions.Add(transaction);
        }

    }
}