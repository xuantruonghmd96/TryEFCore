using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Try_LazyLoad_EagerLoad.Models
{
    public class BranchGroup : GeneralEntity
    {
        public virtual ICollection<BranchGroupMap> BranchGroupMaps { get; set; }
    }
}
