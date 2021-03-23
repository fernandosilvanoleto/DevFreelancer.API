using DevFreelancer.Application.InputModels.ProjectComment;
using DevFreelancer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreelancer.API.Controllers
{
    [Route("api/projectcomments")]
    public class ProjectCommentController : ControllerBase
    {        
        private readonly IProjectCommentService _projectCommentService;
        public ProjectCommentController(IProjectCommentService projectCommentService)
        {
            _projectCommentService = projectCommentService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectCommentService.GetAll();

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
        public async Task<IActionResult> Post([FromBody] CreateProjectCommentInputModel inputModel)
        {            

            // Cadastrar o Projeto
            var id = _projectCommentService.Create(inputModel);
            //var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommentInputModel command)
        {
            _projectCommentService.Update(command);

            return Ok();
        }

    }
}
