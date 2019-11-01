using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Try_LazyLoad_EagerLoad.DTOs;
using Try_LazyLoad_EagerLoad.Models;
using Try_LazyLoad_EagerLoad.Services;

namespace Try_LazyLoad_EagerLoad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        ApiDbContext _dbContext;

        public ProductsController(IProductService productService, ApiDbContext dbContext)
        {
            this._productService = productService;
            this._dbContext = dbContext;
        }

        [HttpGet("One/{amount}/{batch}")]
        public IActionResult GetOne(int amount = 0, int batch = 10)
        {
            var res = this._dbContext.Products.FirstOrDefault();
            return Ok(new ProductModel(res));
            //return this._dbContext.Products.Skip(amount).Take(batch).AsEnumerable().Select(x => new ProductModel(x));
        }

        [HttpGet("One/Eager/{amount}/{batch}")]
        public IActionResult GetOneEager(int amount = 0, int batch = 10)
        {
            var res = this._dbContext.Products
                .Include(x => x.ProductType)
                .Include(x => x.ProductTagMaps).ThenInclude(x => x.ProductTag)
                .Include(x => x.ProductFactoryMaps).ThenInclude(x => x.Factory)
                    .ThenInclude(x => x.Branch)
                        .ThenInclude(x => x.BranchGroupMaps)
                            .ThenInclude(x => x.BranchGroup)
                .FirstOrDefault();
            return Ok(new ProductModel(res));
        }

        [HttpGet("{amount}/{batch}")]
        public IActionResult Get(int amount = 0, int batch = 10)
        {
            var res = this._dbContext.Products.Select(x => new ProductModel(x)).AsEnumerable();
            return Ok(res);
            //return this._dbContext.Products.Skip(amount).Take(batch).AsEnumerable().Select(x => new ProductModel(x));
        }

        [HttpGet("Eager/{amount}/{batch}")]
        public IActionResult GetEager(int amount = 0, int batch = 100)
        {
            //var res = this._dbContext.ProductFactoryMaps.Include(x => x.Product).Include(x => x.Factory);

            //List<FactoryModel> factories = new List<FactoryModel>();
            //foreach (var item in res)
            //{
            //    factories.AddRange(item.Factories);
            //}

            var res = this._dbContext.Products
                .Include(x => x.ProductType)
                .Include(x => x.ProductTagMaps).ThenInclude(x => x.ProductTag)
                .Include(x => x.ProductFactoryMaps).ThenInclude(x => x.Factory)
                    .ThenInclude(x => x.Branch)
                        .ThenInclude(x => x.BranchGroupMaps)
                            .ThenInclude(x => x.BranchGroup)
                .Select(x => new ProductModel(x));

            return Ok(res);
        }
    }
}