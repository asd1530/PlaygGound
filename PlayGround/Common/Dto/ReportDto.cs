using PlayGround.Common.Sie.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Common.Dto
{
    public class ReportDto
    {
        public List<GroupDto> Groupping { get; set; }

        public List<GrouppedAccount> AccountData { get; set; }
    }
}
