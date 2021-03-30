using DevFreelancer.Application.Commands.Skills.CreateSkill;
using DevFreelancer.Application.InputModels.Skill;
using DevFreelancer.Application.Queries.Skills.GetAllSkills;
using DevFreelancer.Application.Queries.Skills.GetSkillById;
using DevFreelancer.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreelancer.API.Controllers
{
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMediator _mediator;
        public SkillsController(ISkillService skillService, IMediator mediator)
        {
            _skillService = skillService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkillsQuery();

            var skills = await _mediator.Send(query);
            //var skills = _skillService.GetAll();

            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var skill = _skillService.GetSkill(id);
            var command = new GetSkillByIdQuery(id);

            var skill = await _mediator.Send(command);

            if (skill == null)
            {
                return Ok("Habilidade não encontrada em nossa base. Por favor, verifique novamente");
            }

            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
        {
            //var id = _skillService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
