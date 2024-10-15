using Domain;
using EfDataAcesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Commands;
using Web_Api.DTOs;

namespace Web_Api.Implementation
{
    public class EfAddProductCommand : BaseCommand, IAddProductCommand
    {

        public EfAddProductCommand(OurDbContext _context) : base(_context)
        {
        }


         public void Execute(CreateProductDto request)
        {

            if (request == null)
                throw new NullReferenceException();
            var id = 0;
            var product = new Product
            {
                ProductName = request.ProductName,
                Price = request.Price,
                Description = request.Description,
                StockQuantity=request.StockQuantity,
                CreatedAt = DateTime.Now,
                
            };

            Context.Products.Add(product);
            Context.SaveChanges();
            id = product.Id;
            Context.ProductCategories.Add(new Domain.ProductCategories
            {
                ProductId = id,
                CategoryId = request.CategoryId
            });
            Context.SaveChanges();


        }
    }
}
