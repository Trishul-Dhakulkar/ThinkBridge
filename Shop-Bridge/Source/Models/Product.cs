using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop_Bridge.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The product name can not be empty")]
        [StringLength(200, ErrorMessage = "The product name should be less than 200 characters")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The product category can not be empty")]
        [StringLength(200, ErrorMessage = "The product name should be less than 200 characters")]
        public string Category { get; set; }
        [StringLength(2000, ErrorMessage = "The product name should be less than 2000 characters")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The product price can not be empty")]
        [Range(0, double.MaxValue, ErrorMessage = " The Product price should not be less than 0")]
        public double Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The product batchNo can not be empty")]
        public string BatchNo { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double NetWt { get; set; }
        public string WtUnit { get; set; }

        public byte[] Image { get; set; }

        public bool IsActive { get; set; }

        public Product()
        {
            ID = 0;
            Name = string.Empty;
            Category = string.Empty;
            Description = string.Empty;
            Price = 0;
            BatchNo = string.Empty;
            NetWt = 0;
            WtUnit = string.Empty;
            Image = null;
            IsActive = false;
        }
    }

    public class ShopBridgeDataModel : DbContext
    {
        public ShopBridgeDataModel()
            : base("name=ShopBridgeDataModel")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

    }
}