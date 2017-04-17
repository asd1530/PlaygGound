using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Sie
{
    /// <summary>
    /// #RAR
    /// </summary>
    
    public class SieBookingYear : BaseSieEntity
    {
        public int FiscalYearId { get; set; }
        public DateTime? Start { get; set;}
        public DateTime? End {get; set;}
    }
}
