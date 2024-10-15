using EfDataAcesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Commands;
using Web_Api.DTOs;
using Web_Api.SearchObj;

namespace Web_Api.Implementation
{
    public class EfGetProductsCommand : BaseCommand, IGetProductsCommand
    {
        public EfGetProductsCommand(OurDbContext _context) : base(_context)
        {
        }

        public IEnumerable<ProductDto> Execute(ProductSearch request)
        {
            var query = Context.Products.AsQueryable();

            if (request.Keyword != null)
            {
                query = query.Where(p => p.ProductName.ToLower().Contains(request.Keyword.ToLower()));
            }

            var product = query.Select(x => new ProductDto
            {
                ProductName = x.ProductName,
                Price = x.Price,
                Description = x.Description,
                StockQuantity = x.StockQuantity,
                ProductId = x.Id,
                Details = x.ProductCategories.Select(c => new ProductCategories
                {
                    CategoryName = c.Category.CategoryName
                }).ToList()
            });
            return product;
        }
    }
}
