using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Common.Dto
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public  List<TreeNode<T>> Children { get; set; }

    }
}
