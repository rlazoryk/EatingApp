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
    public class StatusController : ControllerBase
    {
        private readonly IStatusService statusService;

        public StatusController(IStatusService service)
        {
            statusService = service;
        }

        [HttpGet]
        public ActionResult<List<StatusDTO>> GetAll()
        {
            var result = statusService.GetAll();
            return result;
        }
        [HttpGet("{id}")]
        public ActionResult<StatusDTO> GetById(int id)
        {
            try
            {
                var result = statusService.GetById(id);
                return result;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<StatusDTO> Insert(StatusDTO status)
        {
            var result = statusService.Insert(status);
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult<StatusDTO> Update(StatusDTO status)
        {
            var result = statusService.Update(status);
            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            statusService.Delete(id);
            return NoContent();
        }
    }
}