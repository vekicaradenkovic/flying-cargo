using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.DTOs
{
    public class CreateProductDto
    {
        [MinLength(3, ErrorMessage = "Name must be between 3 - 10 characters"), MaxLength(10, ErrorMessage = "Name must be between 3 - 10 characters")]
        public string ProductName { get; set; }

        public decimal? Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
