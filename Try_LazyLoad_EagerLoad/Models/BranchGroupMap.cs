using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Try_LazyLoad_EagerLoad.Models
{
    public class BranchGroupMap
    {
        public int BranchId { get; set; }
        public int BranchGroupId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual BranchGroup BranchGroup { get; set; }
    }
}
