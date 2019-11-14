using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatingApp.Core.DTO;
using EatingApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EatingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService service)
        {
            orderService = service;
        }

        [HttpGet]
        public ActionResult<List<OrderDTO>> GetAll()
        {
            var result = orderService.GetAll();
            return result;
        }
        [HttpGet("{id}")]
        public ActionResult<OrderDTO> GetById(int id)
        {
            try
            {
                var result = orderService.GetById(id);
                return result;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<OrderDTO> Insert(OrderDTO order)
        {
            var result = orderService.Insert(order);
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult<OrderDTO> Update(OrderDTO order)
        {
            var result = orderService.Update(order);
            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            orderService.Delete(id);
            return NoContent();
        }
    }
}
