using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using Shop_Bridge.Models;
using Shop_Bridge.Controllers;
using System.Web.Http.Results;
using Shop_Bridge.Dtos;

namespace Shop_Bridge.Tests.Controllers
{
    [TestFixture]
    class InventryControllerTests
    {
        private Mock<IProductStorage> _productStorage;
        private InventoryController _inventry;

        [SetUp]
        public void SetUp()
        {
            _productStorage = new Mock<IProductStorage>();
            _inventry = new InventoryController(_productStorage.Object);
        }

        #region GetProducts List Test Cases
        [Test]
        public void GetProducts_WhenCalled_ReturnProductList()
        {
            var result = _inventry.GetProducts();
            Assert.That(result, Is.TypeOf<OkNegotiatedContentResult<List<Product>>>());
        }
        #endregion 

        #region GetProduct Test Cases
        [Test]
        public void GetProduct_WhenCalled_GetProductFromDB()
        {
            var result = _inventry.GetProduct(1);
             _productStorage.Verify(i => i.GetProduct(1));
        }

        [Test]
        public void GetProduct_AfterGetProductFromDB_ReturnProduct()
        {
            var result = _inventry.GetProduct(1);
            Assert.That(result, Is.TypeOf<OkNegotiatedContentResult<Product>>());
        }
        #endregion

        #region RemoveProduct Test Cases

        [Test]
        public void RemoveProduct_WhenCalled_DeleteProductFromDB()
        {
            _inventry.RemoveItem(1);
            _productStorage.Verify(i => i.RemoveProduct(1));
        }

        [Test]
        public void RemoveProduct_AfterProductDelete_ReturnOk()
        {
           var result =  _inventry.RemoveItem(1);
            Assert.That(result, Is.TypeOf<OkResult>());   
        }
        #endregion

        #region AddProduct Test Cases

        [Test]
        public void AddProduct_InvalidModel_ReturnModelStateError()
        {
            ProductDto productDto = new ProductDto
            {
                Name = "TestProduct",
                Category = "TestCategory",
                Description = "This is for testing purpose",
                Price = 100,
                BatchNo = "TestBatch",
                ImageData = null
            };
            _inventry.ModelState.AddModelError("Test", "Input data not valid");
            var result = _inventry.AddProduct(productDto);

            Assert.That(result, Is.TypeOf<InvalidModelStateResult>());
        }

        [Test]
        public void AddProduct_WhenCalled_UpdateRecordInDb()
        {
            ProductDto productDto = new ProductDto
            {
                Name = "TestProduct",
                Category = "TestCategory",
                Description = "This is for testing purpose",
                Price = 100,
                BatchNo = "TestBatch",
                ImageData = null
            };
            _inventry.AddProduct(productDto);
            _productStorage.Verify(p => p.AddProduct(productDto));
        }

        [Test]
        public void AddProduct_AfterAddingProduct_ReturnHttpStatusCreated()
        {
            ProductDto productDto = new ProductDto
            {
                Name = "TestProduct",
                Category = "TestCategory",
                Description = "This is for testing purpose",
                Price = 100,
                BatchNo = "TestBatch",
                ImageData = null
            };
            var result = _inventry.AddProduct(productDto);

            Assert.That(result, Is.TypeOf<CreatedNegotiatedContentResult<Product>>());
        }

        #endregion

        #region UpdateProduct Test Cases

        [Test]
        public void UpdateProduct_InvalidModel_ReturnModelStateError()
        {
            ProductDto productDto = new ProductDto
            {
                Name = "TestProduct",
                Category = "TestCategory",
                Description = "This is for testing purpose",
                Price = 100,
                BatchNo = "TestBatch",
                ImageData = null,
                ID = 1
            };
            _inventry.ModelState.AddModelError("Test", "Input data not valid");
            var result = _inventry.UpdateProduct(1, productDto);
            
            Assert.That(result, Is.TypeOf<InvalidModelStateResult>());
        }
        [Test]
        public void UpdateProduct_IDNotMatch_ReturnBadRequest()
        {
            ProductDto productDto = new ProductDto
            {
                Name = "TestProduct",
                Category = "TestCategory",
                Description = "This is for testing purpose",
                Price = 100,
                BatchNo = "TestBatch",
                ImageData = null,
                ID = 2
            };
            var result = _inventry.UpdateProduct(1, productDto);

            Assert.That(result, Is.TypeOf<BadRequestResult>());
        }

        [Test]
        public void UpdateProduct_WhenCalled_ModifyRecordinDB()
        {
            ProductDto productDto = new ProductDto
            {
                Name = "TestProduct",
                Category = "TestCategory",
                Description = "This is for testing purpose",
                Price = 100,
                BatchNo = "TestBatch",
                ImageData = null,
                ID = 1
            };
            _inventry.UpdateProduct(1, productDto);
            _productStorage.Verify(p => p.UpdateProduct(productDto));
        }

        [Test]
        public void PutItem_AfterUpdateProduct_ReturnNoContent()
        {
            ProductDto productDto = new ProductDto
            {
                Name = "TestProduct",
                Category = "TestCategory",
                Description = "This is for testing purpose",
                Price = 100,
                BatchNo = "TestBatch",
                ImageData = null,
                ID = 1
            };
            var result = _inventry.UpdateProduct(1, productDto);

            Assert.That(result, Is.TypeOf<StatusCodeResult>());
        }

        #endregion
    }
}
