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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService service)
        {
            userService = service;
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetAll()
        {
            var result = userService.GetAll();
            return result;
        }
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetById(int id)
        {
            try
            {
                var result = userService.GetById(id);
                return result;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<UserDTO> Insert(UserDTO user)
        {
            var result = userService.Insert(user);
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult<UserDTO> Update(UserDTO user)
        {
            var result = userService.Update(user);
            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);
            return NoContent();
        }
    }
}