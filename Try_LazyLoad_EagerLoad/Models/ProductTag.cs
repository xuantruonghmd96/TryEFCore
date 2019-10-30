using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Try_LazyLoad_EagerLoad.Models
{
    public class ProductTag : GeneralEntity
    {
        public virtual ICollection<ProductTagMap> ProductTagMaps { get; set; }
    }
}
