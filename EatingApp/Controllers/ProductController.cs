using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatingApp.Core.DTO;
using EatingApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EatingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService service)
        {
            productService = service;
        }

        [HttpGet]
        public ActionResult<List<ProductDTO>> GetAll()
        {
            var result = productService.GetAll();
            return result;
        }
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetById(int id)
        {
            try
            {
                var result = productService.GetById(id);
                return result;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ProductDTO> Insert(ProductDTO product)
        {
            var result = productService.Insert(product);
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult<ProductDTO> Update(ProductDTO product)
        {
            var result = productService.Update(product);
            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productService.Delete(id);
            return NoContent();
        }
    }
}