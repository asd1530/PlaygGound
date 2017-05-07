using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Common.Dto
{
    public class GroupDto
    {
        public string Key { get; set; }

        public List<SubGroupDto> SubGroups { get; set; }

    }
}
