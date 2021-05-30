using AutoMapper;
using Shop_Bridge.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace Shop_Bridge.Models
{
    public interface IProductStorage
    {
        Product AddProduct(ProductDto productDto);
        Product GetProduct(int id);
        List<Product> GetProducts();
        void RemoveProduct(int id);
        void UpdateProduct(ProductDto productDto);
    }

    public class ProductStorage : IProductStorage
    {
        private ShopBridgeDataModel _db;

        public ProductStorage()
        {
            _db = new ShopBridgeDataModel();
        }

        public List<Product> GetProducts()
        {
            return _db.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public Product AddProduct(ProductDto productDto)
        {
            var product = Mapper.Map<ProductDto, Product>(productDto);
            if (productDto.ImageData != null && productDto.ImageData.Length > 0)
            {
                product.Image = Convert.FromBase64String(productDto.ImageData);
            }
            _db.Products.Add(product);
            _db.SaveChanges();

            return product;
        }

        public void UpdateProduct(ProductDto productDto)
        {
            var productInDb = _db.Products.SingleOrDefault(c => c.ID == productDto.ID);

            if (productInDb == null)
                return;
            else
            {
                Mapper.Map(productDto, productInDb);
                if (productDto.ImageData != null && productDto.ImageData.Length > 0)
                {
                    productInDb.Image = Convert.FromBase64String(productDto.ImageData);
                }
            }
            _db.SaveChanges();
        }

        public void RemoveProduct(int id)
        {
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return;
            }
            _db.Products.Remove(product);
            _db.SaveChanges();
        }
    }
}