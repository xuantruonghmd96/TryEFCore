using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try_LazyLoad_EagerLoad.DTOs;
using Try_LazyLoad_EagerLoad.Models;
using Try_LazyLoad_EagerLoad.Repositories;

namespace Try_LazyLoad_EagerLoad.Services
{
    public class ProductService : EntityService<Product>, IProductService
    {
        readonly IProductRepository _repository;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository) : base(unitOfWork, productRepository)
        {
            _repository = productRepository;
        }
    }
}
