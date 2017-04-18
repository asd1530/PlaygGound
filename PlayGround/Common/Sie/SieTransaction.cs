using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Common.Sie
{
    public class SieTransaction : Resource
    {
        public int FileImportId { get; set; }
        public string VoucherKey { get; set; }
        public string Account { get; set; }
        public string DimensionKey { get; set; }
        public decimal Amount { get; set; }
        public DateMonth RowDate { get; set; }
        public string Text { get; set; }
        public decimal? Quantity;
        public string CreatedBy { get; set; }
        public string Token { get; set; }
    }
}
