using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Try_LazyLoad_EagerLoad.Models
{
    public class ProductFactoryMap
    {
        public int ProductId { get; set; }
        public int FactoryId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Factory Factory { get; set; }
    }
}
