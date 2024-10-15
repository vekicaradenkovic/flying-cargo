using EfDataAcesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Commands;
using Web_Api.DTOs;

namespace Web_Api.Implementation
{
    public class EfEditProductCommand : BaseCommand, IEditProductCommand
    {
        public EfEditProductCommand(OurDbContext _context) : base(_context)
        {
        }

        public void Execute(ProductDto request)
        {
            var product = Context.Products.Find(request.ProductId);

            if (product == null)
                throw new NullReferenceException();

            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.Description = request.Description;
            product.StockQuantity = request.StockQuantity;

            Context.Products.Update(product);
            Context.SaveChanges();
        }
    }
}
