using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.DTOs
{
    public class ProductDto
    {

        public ProductDto()
        {

            Details = new List<ProductCategories>();
        }


        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public decimal? Price { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public List<ProductCategories> Details { get; set; }
    }
}
