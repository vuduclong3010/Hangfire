using HangfileService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangfileService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexsController : ControllerBase
    {
        private readonly IUsersService service;

        public IndexsController(IUsersService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = service.GetUsers();
            return Ok(result);
        }
    }
}
