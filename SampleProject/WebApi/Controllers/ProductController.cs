﻿using Core.Services.Products;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductService _getProductService;
        private readonly IUpdateProductService _updateProductService;

        public ProductController(ICreateProductService createProductService, IDeleteProductService deleteProductService, IGetProductService getProductService, IUpdateProductService updateProductService)
        {
            _createProductService = createProductService;
            _deleteProductService = deleteProductService;
            _getProductService = getProductService;
            _updateProductService = updateProductService;
        }

        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {
            var product = _createProductService.Create(productId, model.Name, model.Cost);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {
            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _updateProductService.Update(product, model.Name, model.Cost);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _deleteProductService.Delete(product);
            return Found();
        }

        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);
            return Found(new ProductData(product));
        }

        //[Route("list")]
        //[HttpGet]
        //public HttpResponseMessage GetProducts(int skip, int take, ProductTypes? type = null, string name = null, string email = null)
        //{
        //    var products = _getProductService.GetProducts(type, name, email)
        //                               .Skip(skip).Take(take)
        //                               .Select(q => new ProductData(q))
        //                               .ToList();
        //    return Found(products);
        //}

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllProducts()
        {
            _deleteProductService.DeleteAll();
            return Found();
        }

        [Route("list/tag")]
        [HttpGet]
        public HttpResponseMessage GetProductsByTag(string tag)
        {
            var products = _getProductService.GetProductsByTag(tag)
                                  //.Skip(skip).Take(take)
                                  //.Select(q => new ProductData(q))
                                  .ToList();
            return Found(products);
        }
    }
}