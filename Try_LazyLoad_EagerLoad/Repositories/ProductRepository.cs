using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try_LazyLoad_EagerLoad.Models;

namespace Try_LazyLoad_EagerLoad.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
