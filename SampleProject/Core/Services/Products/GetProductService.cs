using BusinessEntities;
using Common;
using Core.Services.products;
using Core.Services.Products;
using Data.Repositories;
using System;
using System.Collections.Generic;

namespace Core.Services.products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> GetProducts(string name = null, string email = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByTag(string tag)
        {
            return null; //todo: _productRepository.GetByTag(tag);
        }
    }
}