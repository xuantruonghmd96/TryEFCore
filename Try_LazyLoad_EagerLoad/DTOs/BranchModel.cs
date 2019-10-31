using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try_LazyLoad_EagerLoad.Models;

namespace Try_LazyLoad_EagerLoad.DTOs
{
    public class BranchModel : BaseModel
    {
        public IEnumerable<BranchGroupModel> BranchGroups { get; set; }
        public IEnumerable<FactoryModel> Factories { get; set; }

        public BranchModel(Branch branch) : base(branch.Id, branch.Name, branch.Description)
        {
            this.BranchGroups = branch.BranchGroupMaps?.Select(x => new BranchGroupModel(x));
        }
    }
}
