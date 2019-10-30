using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Try_LazyLoad_EagerLoad.Models
{
    public class Factory : GeneralEntity
    {
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ProductFactoryMap ProductFactoryMaps { get; set; }
    }
}
