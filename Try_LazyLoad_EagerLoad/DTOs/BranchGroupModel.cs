using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try_LazyLoad_EagerLoad.Models;

namespace Try_LazyLoad_EagerLoad.DTOs
{
    public class BranchGroupModel : BaseModel
    {
        public IEnumerable<BranchModel> Branches { get; set; }

        public BranchGroupModel(BranchGroupMap branchGroupMap)
        {
            this.Id = branchGroupMap.BranchGroup.Id;
            this.Name = branchGroupMap.BranchGroup.Name;
            this.Description = branchGroupMap.BranchGroup.Description;
        }
    }
}
