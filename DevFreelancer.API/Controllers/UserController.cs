using DevFreelancer.Application.InputModels;
using DevFreelancer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelancer.API.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return Ok("Usuário não encontrado em nossa base. Por favor, verifique novamente");
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            var id = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateUserInputModel inputModel)
        {
            _userService.Update(inputModel);

            return Ok();
        }
    }
}
