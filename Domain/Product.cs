using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal? Price { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public ICollection<ProductCategories> ProductCategories { get; set; }
    }
}
