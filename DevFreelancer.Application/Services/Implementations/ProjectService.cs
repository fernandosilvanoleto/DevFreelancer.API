using DevFreelancer.Application.InputModels;
using DevFreelancer.Application.Services.Interfaces;
using DevFreelancer.Application.ViewModels;
using DevFreelancer.Core.Entities;
using DevFreelancer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DevFreelancer.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelancerDbContext _dbContext;
        private readonly string _connectionString;
        public ProjectService(DevFreelancerDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelancer");
        }
        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost, inputModel.FinishedAt);

            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return project.Id;
        }

        //public void CreateComment(CreateCommentInputModel inputModel)
        //{
        //    var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

        //    _dbContext.ProjectComments.Add(comment);
        //    _dbContext.SaveChanges();
        //}

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();
            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Finish();
            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                    project.Id,
                    project.Title,
                    project.Description,
                    project.TotalCost,
                    project.StartedAt,
                    project.FinishedAt,
                    project.Client.FullName,
                    project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();
            _dbContext.SaveChanges();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(project.Title, project.Description, project.TotalCost);
            _dbContext.SaveChanges();
        }
    }
}
