using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Try_LazyLoad_EagerLoad.Models
{
    public class ProductType : GeneralEntity
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
