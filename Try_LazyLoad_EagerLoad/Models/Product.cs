using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Try_LazyLoad_EagerLoad.Models
{
    public class Product : GeneralEntity
    {
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public virtual ICollection<ProductFactoryMap> ProductFactoryMaps { get; set; }
        public virtual ICollection<ProductTagMap> ProductTagMaps { get; set; }
    }
}
