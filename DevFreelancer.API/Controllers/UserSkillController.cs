using DevFreelancer.Application.Commands.UserSkills.UserSkillCommand;
using DevFreelancer.Application.InputModels.UserSkill;
using DevFreelancer.Application.Queries.UserSkill.GetAllUserSkill;
using DevFreelancer.Application.Queries.UserSkill.GetUserSkillById;
using DevFreelancer.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreelancer.API.Controllers
{
    [Route("api/userskils")]
    public class UserSkillController : ControllerBase
    {
        private readonly IUserSkillService _userSkillService;
        private readonly IMediator _mediator;
        public UserSkillController(IUserSkillService userSkillService, IMediator mediator)
        {
            _userSkillService = userSkillService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var userSkills = _userSkillService.GetAll();
            var getAllUserSkillsQuery = new GetAllUserSkillQuery();

            var userSkills = await _mediator.Send(getAllUserSkillsQuery);

            return Ok(userSkills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var userSkill = _userSkillService.GetUserSkill(id);
            var command = new GetUserSkillByIdQuery(id);

            var userSkill = await _mediator.Send(command);

            if (userSkill == null)
            {
                return Ok("Usuário com Habilidade não encontrado em nossa base. Por favor, verifique novamente");
            }

            return Ok(userSkill);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserSkillCommand command)
        {
            //var id = _userSkillService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
