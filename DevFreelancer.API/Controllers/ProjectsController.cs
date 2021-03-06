using DevFreelancer.Application.Commands.Projects.CreateProject;
using DevFreelancer.Application.Commands.Projects.DeleteProject;
using DevFreelancer.Application.Commands.Projects.FinishProject;
using DevFreelancer.Application.Commands.Projects.StartProject;
using DevFreelancer.Application.Commands.Projects.UpdateProject;
using DevFreelancer.Application.InputModels;
using DevFreelancer.Application.Queries.Projects.GetAllProjects;
using DevFreelancer.Application.Queries.Projects.GetProjectById;
using DevFreelancer.Application.Services.Implementations;
using DevFreelancer.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreelancer.API.Controllers
{
    [Route("api/projects")]
    [Authorize]
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
        public async Task<IActionResult> Get(string query)
        {
            // buscar todos ou filtrar
            //var projects = _projectService.GetAll(query);

            var getAllProjectsQuery = new GetAllProjectQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // buscar todos ou filtrar

            //var project = _projectService.GetById(id);
            var command = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(command);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {           

            if (command.Title.Length > 50)
            {
                return BadRequest();
            }

            // Cadastrar o Projeto
            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
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
        public async Task<IActionResult> PostComment(int id)
        {
            //_projectService.CreateComment(inputModel);
            await _mediator.Send(null);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            //_projectService.Start(id);
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            //_projectService.Finish(id);
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
