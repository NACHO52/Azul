using Azul.Repository;
using Azul.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Azul.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserController : ControllerBase
    {
        private readonly ISystemUserRepository _repository;
        public SystemUserController(ISystemUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<SystemUser>> Get()
        {
            return await _repository.GetAll();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            SystemUser user = new SystemUser();

            user = await _repository.Get(login.Username, login.Password);

            return StatusCode(StatusCodes.Status200OK, user);
        }
    }
}
