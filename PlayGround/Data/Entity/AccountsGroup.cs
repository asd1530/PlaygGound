using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Data.Entity
{
    public class AccountsGroup
    {
        public int Id { get; set; }
        public string GroupKey { get; set; }
        public string AccountStart { get; set; }
        public string AccountEnd { get; set; }
        public string Parent { get; set; }
        public int Level{ get; set; }
        public DateTime Modified { get; set; }
    }
}
