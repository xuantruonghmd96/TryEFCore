using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try_LazyLoad_EagerLoad.Models;

namespace Try_LazyLoad_EagerLoad.DTOs
{
    public class ProductTagModel : BaseModel
    {
        public IEnumerable<ProductModel> Products { get; set; }

        public ProductTagModel(ProductTagMap productTagMap)
        {
            this.Id = productTagMap.ProductTag.Id;
            this.Name = productTagMap.ProductTag.Name;
            this.Description = productTagMap.ProductTag.Description;
        }
    }
}
