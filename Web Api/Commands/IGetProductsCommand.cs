using GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.DTOs;
using Web_Api.SearchObj;

namespace Web_Api.Commands
{
    public interface IGetProductsCommand : ICommand<ProductSearch, IEnumerable<ProductDto>>
    {
    }
}
