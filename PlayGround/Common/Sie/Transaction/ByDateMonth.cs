using Common.Sie;
using System.Collections.Generic;

namespace PlayGround.Common.Sie.Transaction
{
    public class ByDateMonth
    {
        public DateMonth Period { get; set; }
        public List<SieVoucherRow> Transactions { get; set; }

        public ByDateMonth()
        {
            this.Transactions = new List<SieVoucherRow>();
        }

        public void Add(SieVoucherRow transaction)
        {
            this.Period = new DateMonth(transaction.RowDate);
            this.Transactions.Add(transaction);
        }
    }
}