using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Try_LazyLoad_EagerLoad.Models
{
    public class ProductTagMap
    {
        public int ProductId { get; set; }
        public int ProductTagId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductTag ProductTag { get; set; }
    }
}
