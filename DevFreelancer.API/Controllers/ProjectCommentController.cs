using DevFreelancer.Application.Commands.ProjectComments.CreateComment;
using DevFreelancer.Application.Commands.ProjectComments.UpdateComment;
using DevFreelancer.Application.InputModels.ProjectComment;
using DevFreelancer.Application.Queries.ProjectComments.GetAllProjectComments;
using DevFreelancer.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreelancer.API.Controllers
{
    [Route("api/projectcomments")]
    public class ProjectCommentController : ControllerBase
    {        
        private readonly IProjectCommentService _projectCommentService;
        private readonly IMediator _mediator;
        public ProjectCommentController(IProjectCommentService projectCommentService, IMediator mediator)
        {
            _projectCommentService = projectCommentService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            //var projects = _projectCommentService.GetAll();
            var command = new GetAllProjectCommentQuery();

            var projects = await _mediator.Send(command);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // buscar todos ou filtrar

           var projectComment = _projectCommentService.GetProjectComment(id);            

            if (projectComment == null)
            {
                return NotFound();
            }

            return Ok(projectComment);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommentCommand command)
        {            

            // Cadastrar o Projeto
            // var id = _projectCommentService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommentCommand command)
        {
            //_projectCommentService.Update(command);

            await _mediator.Send(command);

            return Ok();
        }

    }
}
