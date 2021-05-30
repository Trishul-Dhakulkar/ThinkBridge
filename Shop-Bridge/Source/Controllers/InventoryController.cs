using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Shop_Bridge;
using Shop_Bridge.Dtos;
using Shop_Bridge.Models;

namespace Shop_Bridge.Controllers
{
    public class InventoryController : ApiController
    {
        private IProductStorage _productStorage;
        private ShopBridgeDataModel db ;
        public InventoryController()
        {
             db = new ShopBridgeDataModel();
            _productStorage = new ProductStorage();
        }
        public InventoryController(IProductStorage productStorage = null, ShopBridgeDataModel shopBridgeDataModel = null)
        {
            _productStorage = productStorage ?? new ProductStorage();
            db = shopBridgeDataModel ?? new ShopBridgeDataModel();
        }

        /// <summary>
        /// Get List of all Product
        /// </summary>
        /// <returns></returns>
        // GET: api/Items
        public IHttpActionResult GetProducts()
        {
            var productlist = _productStorage.GetProducts();

             return Ok(productlist);
        }

        /// <summary>
        /// Get specific product details based on given Product ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        // GET: api/Items/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
           var product = _productStorage.GetProduct(id);
           return Ok(product);
        }

        /// <summary>
        /// Update the specific product details based on given Product ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpPut]
        // PUT: api/Items/5
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDto.ID)
            {
                return BadRequest();
            }

            _productStorage.UpdateProduct(productDto);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Add new Product to Product List
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpPost]
        // POST: api/Items
        [ResponseType(typeof(Product))]
        public IHttpActionResult AddProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var product = _productStorage.AddProduct(productDto);

            return Created("InventoryApi", product);
        }

        /// <summary>
        /// Remove a specific product based on given Product ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        // DELETE: api/Items/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult RemoveItem(int id)
        {
            _productStorage.RemoveProduct(id);
             return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}