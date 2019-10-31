using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try_LazyLoad_EagerLoad.Models;

namespace Try_LazyLoad_EagerLoad.DTOs
{
    public class FactoryModel : BaseModel
    {
        public BranchModel Branch { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }

        public FactoryModel(Factory factory)
        {
            if (factory == null)
                return;
            Id = factory.Id;
            Name = factory.Name;
            Description = factory.Description;
            this.Branch = factory.Branch == null ? null : new BranchModel(factory.Branch);
        }
    }
}
