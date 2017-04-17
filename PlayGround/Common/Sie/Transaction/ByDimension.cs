using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Sie;

namespace PlayGround.Common.Sie.Transaction
{
    public class ByDimension
    {
        public string DimensionNumber { get; set; }
        public ByAccount Transactions { get; set; }

        public ByDimension()
        {
            this.Transactions = new ByAccount();
        }
        public void Add(SieVoucherRow transaction)
        {
            if (transaction.Objects == null)
            {
                transaction.Objects = new List<SieObject>()
                {
                    new SieObject()
                    {
                        Dimension = null,
                        Name = "All",
                        Number = string.Empty
                    }
                };
            }
            this.DimensionNumber = transaction.Objects.Last().Number;
            this.Transactions.Add(transaction);
        }

    }
}
