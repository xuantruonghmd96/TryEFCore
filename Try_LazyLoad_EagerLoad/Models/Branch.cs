using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Try_LazyLoad_EagerLoad.Models
{
    public class Branch : GeneralEntity
    {
        public virtual ICollection<BranchGroupMap> BranchGroupMaps { get; set; }
        public virtual ICollection<Factory> Factories { get; set; }
    }
}
