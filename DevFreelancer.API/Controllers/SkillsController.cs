using DevFreelancer.Application.InputModels.Skill;
using DevFreelancer.Application.Queries.GetAllSkills;
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
            //var query = new GetAllSkillsQuery();

            //var skills = await _mediator.Send(query);
            var skills = _skillService.GetAll();

            return Ok(skills);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var skill = _skillService.GetSkill(id);

            if (skill == null)
            {
                return Ok("Habilidade não encontrada em nossa base. Por favor, verifique novamente");
            }

            return Ok(skill);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateSkillInputModel inputModel)
        {
            var id = _skillService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }
    }
}
