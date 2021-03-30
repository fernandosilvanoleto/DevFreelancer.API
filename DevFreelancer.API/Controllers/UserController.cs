using DevFreelancer.Application.Commands.Users.CreateUser;
using DevFreelancer.Application.Commands.Users.UpdateUser;
using DevFreelancer.Application.InputModels;
using DevFreelancer.Application.Queries.Users.GetAllUser;
using DevFreelancer.Application.Queries.Users.GetUserById;
using DevFreelancer.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreelancer.API.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;
        public UserController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var users = _userService.GetAll();
            var getAllUsersQuery = new GetAllUserQuery();

            var users = await _mediator.Send(getAllUsersQuery);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var user = _userService.GetUser(id);
            var command = new GetUserByIdQuery(id);

            var user = await _mediator.Send(command);

            if (user == null)
            {
                return Ok("Usuário não encontrado em nossa base. Por favor, verifique novamente");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            //var id = _userService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            //_userService.Update(inputModel);
            if (command == null)            
                return NotFound();
            
            await _mediator.Send(command);

            return Ok();
        }
    }
}
