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
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService productTypeService;

        public ProductTypeController(IProductTypeService service)
        {
            productTypeService = service;
        }

        [HttpGet]
        public ActionResult<List<ProductTypeDTO>> GetAll()
        {
            var result = productTypeService.GetAll();
            return result;
        }
        [HttpGet("{id}")]
        public ActionResult<ProductTypeDTO> GetById(int id)
        {
            try
            {
                var result = productTypeService.GetById(id);
                return result;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ProductTypeDTO> Insert(ProductTypeDTO productType)
        {
            var result = productTypeService.Insert(productType);
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult<ProductTypeDTO> Update(ProductTypeDTO productType)
        {
            var result = productTypeService.Update(productType);
            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productTypeService.Delete(id);
            return NoContent();
        }
    }
}