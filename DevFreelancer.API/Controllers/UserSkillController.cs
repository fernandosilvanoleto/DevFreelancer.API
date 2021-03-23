using DevFreelancer.Application.InputModels.UserSkill;
using DevFreelancer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelancer.API.Controllers
{
    [Route("api/userskils")]
    public class UserSkillController : ControllerBase
    {
        private readonly IUserSkillService _userSkillService;
        public UserSkillController(IUserSkillService userSkillService)
        {
            _userSkillService = userSkillService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userSkills = _userSkillService.GetAll();

            return Ok(userSkills);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userSkill = _userSkillService.GetUserSkill(id);

            if (userSkill == null)
            {
                return Ok("Usuário com Habilidade não encontrado em nossa base. Por favor, verifique novamente");
            }

            return Ok(userSkill);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserSkillInputModel inputModel)
        {
            var id = _userSkillService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }
    }
}
