using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Try_LazyLoad_EagerLoad.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchGroup> BranchGroups { get; set; }
        //public DbSet<Factory> Factories { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<BranchGroupMap> BranchGroupMaps { get; set; }
        //public DbSet<ProductCategoryMap> ProductCategoryMaps { get; set; }
        //public DbSet<ProductFactoryMap> ProductFactoryMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BranchGroupMap>().HasKey(x => new { x.BranchId, x.BranchGroupId });
            //modelBuilder.Entity<ProductCategoryMap>().HasKey(x => new { x.ProductId, x.CategoryId });
            //modelBuilder.Entity<ProductFactoryMap>().HasKey(x => new { x.ProductId, x.FactoryId });
            //modelBuilder.Entity<BranchGroupMap>().HasNoKey();
            //modelBuilder.Entity<ProductCategoryMap>().HasNoKey();
            //modelBuilder.Entity<ProductFactoryMap>().HasNoKey();
        }
    }
}
