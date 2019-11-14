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
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService orderItemService;

        public OrderItemController(IOrderItemService service)
        {
            orderItemService = service;
        }

        [HttpGet]
        public ActionResult<List<OrderItemDTO>> GetAll()
        {
            var result = orderItemService.GetAll();
            return result;
        }
        [HttpGet("{id}")]
        public ActionResult<OrderItemDTO> GetById(int id)
        {
            try
            {
                var result = orderItemService.GetById(id);
                return result;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<OrderItemDTO> Insert(OrderItemDTO orderItem)
        {
            var result = orderItemService.Insert(orderItem);
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult<OrderItemDTO> Update(OrderItemDTO orderItem)
        {
            var result = orderItemService.Update(orderItem);
            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            orderItemService.Delete(id);
            return NoContent();
        }
    }
}