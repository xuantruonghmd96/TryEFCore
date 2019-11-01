using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var res = new ProductModel(this._dbContext.Products
                .FirstOrDefault(x => x.Id == 50));

            sw.Stop();
            Console.WriteLine("////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////// Lazy Load Elapsed = {0}", sw.Elapsed);
            Console.WriteLine("////////////////////////////////////");

            string name = res.Factories.First().Branch.Name;

            return Ok(res);
            //return this._dbContext.Products.Skip(amount).Take(batch).AsEnumerable().Select(x => new ProductModel(x));
        }

        [HttpGet("One/Eager/{amount}/{batch}")]
        public IActionResult GetOneEager(int amount = 0, int batch = 10)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var res = new ProductModel(this._dbContext.Products
                .Include(x => x.ProductType)
                .Include(x => x.ProductTagMaps).ThenInclude(x => x.ProductTag)
                .Include(x => x.ProductFactoryMaps).ThenInclude(x => x.Factory)
                    .ThenInclude(x => x.Branch)
                        .ThenInclude(x => x.BranchGroupMaps)
                            .ThenInclude(x => x.BranchGroup)
                .FirstOrDefault(x => x.Id == 50));

            sw.Stop();
            Console.WriteLine("////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////// Eager Load Elapsed = {0}", sw.Elapsed);
            Console.WriteLine("////////////////////////////////////");

            string name = res.Factories.First().Branch.Name;

            return Ok(res);
        }

        [HttpGet("{amount}/{batch}")]
        public IActionResult Get(int amount = 0, int batch = 10)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var res = this._dbContext.Products
                .Where(x => x.Name.Contains("Product - 1")).Skip(amount).Take(batch)
                .Select(x => new ProductModel(x))
                .ToList();

            sw.Stop();
            Console.WriteLine("////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////// Lazy Load Elapsed = {0}", sw.Elapsed);
            Console.WriteLine("////////////////////////////////////");

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

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var res = this._dbContext.Products
                .Include(x => x.ProductType)
                .Include(x => x.ProductTagMaps).ThenInclude(x => x.ProductTag)
                .Include(x => x.ProductFactoryMaps).ThenInclude(x => x.Factory)
                    .ThenInclude(x => x.Branch)
                        .ThenInclude(x => x.BranchGroupMaps)
                            .ThenInclude(x => x.BranchGroup)
                .Where(x => x.Name.Contains("Product - 1")).Skip(amount).Take(batch)
                .Select(x => new ProductModel(x))
                .ToList();

            sw.Stop();
            Console.WriteLine("////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////// Eager Load Elapsed = {0}", sw.Elapsed);
            Console.WriteLine("////////////////////////////////////");

            return Ok(res);
        }
    }
}