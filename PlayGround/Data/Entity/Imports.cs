using System;
using System.Collections.Generic;

namespace PlayGround.Data.Entity
{
    public partial class Imports
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime Modified { get; set; }
        public int Status { get; set; }
    }
}
