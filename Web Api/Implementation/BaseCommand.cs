using EfDataAcesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.Implementation
{
    public class BaseCommand
    {
        protected OurDbContext Context {get;}

        public BaseCommand(OurDbContext _context)
        {
            Context = _context;
        }
    }
}
