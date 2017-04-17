using System.Collections.Generic;

namespace Common.Sie
{
    public class SiePeriodValue : BaseSieEntity
    {
        public SieAccount Account;
        public int YearNr;
        public int Period;
        public decimal Amount;
        public decimal? Quantity;
        public List<SieObject> Objects;
        public string Token;

        public SieVoucherRow ToVoucherRow()
        {
            var vr = new SieVoucherRow()
            {
                Account = this.Account,
                Amount = this.Amount,
                Objects = this.Objects,
                Quantity = this.Quantity
            };
            return vr;
        }

        public SieVoucherRow ToInvertedVoucherRow()
        {
            var vr = ToVoucherRow();
            vr.Amount *= -1;

            return vr;
        }

    }
}
