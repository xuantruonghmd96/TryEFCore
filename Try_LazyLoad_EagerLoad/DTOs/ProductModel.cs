using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try_LazyLoad_EagerLoad.Models;

namespace Try_LazyLoad_EagerLoad.DTOs
{
    public class ProductModel : BaseModel
    {
        public ProductTypeModel ProductType { get; set; }
        public IEnumerable<ProductTagModel> ProductTags { get; set; }
        public IEnumerable<FactoryModel> Factories { get; set; }

        public ProductModel(Product product) : base(product.Id, product.Name, product.Description)
        {
            this.ProductType = product.ProductType == null ? null : new ProductTypeModel(product.ProductType);
            this.ProductTags = product.ProductTagMaps?.Select(x => new ProductTagModel(x));
            this.Factories = product.ProductFactoryMaps?.Select(x => new FactoryModel(x.Factory));
        }

        public ProductModel()
        {
        }
    }
}
