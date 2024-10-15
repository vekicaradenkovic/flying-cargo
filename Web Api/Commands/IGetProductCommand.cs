using GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.DTOs;

namespace Web_Api.Commands
{
    public interface IGetProductCommand : ICommand<int,ProductDto>
    {
    }
}
