using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name is required")]
        [StringLength(100, ErrorMessage = "Product Name should not exceed 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Product Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Product Price is required")]
        [Range(1, 100000, ErrorMessage = "Price should be between 1 and 100000")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Product Stock Quantity is required")]
        [Range(1, 100000, ErrorMessage = "Stock Quantity should be between 1 and 100000")]
        public int StockQuantity { get; set; }
    }
}
