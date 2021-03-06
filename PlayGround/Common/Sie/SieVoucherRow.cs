﻿using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;

namespace Common.Sie
{

    public class SieVoucherRow : Resource
    {
        public SieAccount Account { get; set; }
        public List<SieObject> Objects { get; set; }
        public string DimensionKey { get; set; }
        public decimal Amount { get; set; }
        public DateTime RowDate { get; set; }
        public string Text { get; set; }
        public decimal? Quantity;
        public string CreatedBy { get; set; }
        public string Token { get; set; }
    }
}
