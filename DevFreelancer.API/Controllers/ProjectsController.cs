using DevFreelancer.Application.Commands.CreateComment;
using DevFreelancer.Application.Commands.CreateProject;
using DevFreelancer.Application.Commands.DeleteProject;
using DevFreelancer.Application.Commands.UpdateProject;
using DevFreelancer.Application.InputModels;
using DevFreelancer.Application.Queries.GetAllProjects;
using DevFreelancer.Application.Services.Implementations;
using DevFreelancer.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreelancer.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;
        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            // buscar todos ou filtrar

            var projects = _projectService.GetAll(query);

            //var getAllProjectsQuery = new GetAllProjectsQuery(query);

            //var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // buscar todos ou filtrar

            var project = _projectService.GetById(id);

            if(project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewProjectInputModel inputModel)
        {
            if(inputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            // Cadastrar o Projeto
            var id = _projectService.Create(inputModel);
            //var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if(command.Description.Length > 200)
            {
                return BadRequest();
            }

            //_projectService.Update(inputModel);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //_projectService.Delete(id);
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            //_projectService.CreateComment(inputModel);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}
