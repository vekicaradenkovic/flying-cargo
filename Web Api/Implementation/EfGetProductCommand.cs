using EfDataAcesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Commands;
using Web_Api.DTOs;

namespace Web_Api.Implementation
{
    public class EfGetProductCommand : BaseCommand, IGetProductCommand
    {
        public EfGetProductCommand(OurDbContext _context) : base(_context)
        {
        }

        public ProductDto Execute(int request)
        {
            var product = Context.Products.Find(request);

            if (product == null)
                throw new NullReferenceException();

            return new ProductDto
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                ProductId = product.Id
            };
        }
    }
}
