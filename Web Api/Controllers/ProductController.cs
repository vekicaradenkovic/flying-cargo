using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web_Api.Commands;
using Web_Api.DTOs;
using Web_Api.SearchObj;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IAddProductCommand addProductCommand;
        private readonly IGetProductsCommand getProductsCommand;
        private readonly IGetProductCommand getProductCommand;
        private readonly IEditProductCommand editProductCommand;
        private readonly IDeleteProductCommand deleteProductCommand;

        public ProductController(IAddProductCommand _addProductCommand, IGetProductsCommand _getProductsCommand, IGetProductCommand _getProductCommand, IEditProductCommand _editProductCommand, IDeleteProductCommand _deleteProductCommand)
        {
            addProductCommand = _addProductCommand;
            getProductsCommand = _getProductsCommand;
            getProductCommand = _getProductCommand;
            editProductCommand = _editProductCommand;
            deleteProductCommand = _deleteProductCommand;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearch search)
        {
            var dto = getProductsCommand.Execute(search);
            return Ok(dto); // Return products as JSON
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dto = getProductCommand.Execute(id);
            return Ok(dto); // Return product details as JSON
        }

        // POST: api/product
        [HttpPost]
        public IActionResult Create([FromBody] CreateProductDto dto)
        {
            try
            {
                addProductCommand.Execute(dto);
                return Created("/api/product", dto); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return 400 Bad Request
            }
        }

        // PUT: api/product/5
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] ProductDto dto)
        {
            try
            {
                dto.ProductId = id;
                editProductCommand.Execute(dto);
                return NoContent(); // Return 204 No Content
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return 400 Bad Request
            }
        }

        // DELETE: api/product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteProductCommand.Execute(id);
                return NoContent(); // Return 204 No Content
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return 400 Bad Request
            }
        }
    }
}
