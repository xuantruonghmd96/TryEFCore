using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try_LazyLoad_EagerLoad.Models;

namespace Try_LazyLoad_EagerLoad.DTOs
{
    public class ProductTypeModel : BaseModel
    {
        public IEnumerable<ProductModel> Products { get; set; }

        public ProductTypeModel(ProductType productType) : base(productType.Id, productType.Name, productType.Description)
        {
            //this.Products = productType.Products.Select(x => new ProductModel(x));
        }

        public ProductTypeModel()
        {
        }
    }
}
