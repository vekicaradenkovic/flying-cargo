using EfDataAcesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Commands;

namespace Web_Api.Implementation
{
    public class EfDeleteProductCommand : BaseCommand, IDeleteProductCommand
    {
        public EfDeleteProductCommand(OurDbContext _context) : base(_context)
        {
        }

        public void Execute(int request)
        {
            var product = Context.Products.Find(request);

            if (request == 0)
                throw new NullReferenceException();
            if (product == null)

                throw new NullReferenceException();

            Context.Products.Remove(product);
            Context.SaveChanges();
        }
    }
}
