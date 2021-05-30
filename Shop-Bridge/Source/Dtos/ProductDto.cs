using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop_Bridge.Dtos
{
    public class ProductDto
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
        public string ImageData { get; set; }
        public bool IsActive { get; set; }

    }
}