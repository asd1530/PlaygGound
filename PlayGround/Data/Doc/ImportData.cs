using Common.Sie;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Data.Doc
{
    public class ImportData : Resource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<SieAccount> Accounts { get; set; }
    }
}
