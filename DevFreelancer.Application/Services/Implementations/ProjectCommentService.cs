using DevFreelancer.Application.InputModels.ProjectComment;
using DevFreelancer.Application.Services.Interfaces;
using DevFreelancer.Application.ViewModels.ProjectComment;
using DevFreelancer.Core.Entities;
using DevFreelancer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DevFreelancer.Application.Services.Implementations
{
    public class ProjectCommentService : IProjectCommentService
    {
        private readonly DevFreelancerDbContext _dbContext;
        public ProjectCommentService(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(CreateProjectCommentInputModel inputModel)
        {
            var projectComment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContext.ProjectComments.Add(projectComment);
            _dbContext.SaveChanges();

            return projectComment.Id;
        }

        public List<ProjectCommentViewAllModel> GetAll()
        {
            var projectComments = _dbContext.ProjectComments;

            var projectCommentViewAllModel = projectComments
                .Include(pr => pr.Project)
                .Include(u => u.User)
                .Select(pc => new ProjectCommentViewAllModel(pc.Id, pc.Content, pc.Project.Title, pc.User.FullName, pc.CreatedAt))
                .ToList();

            return projectCommentViewAllModel;
        }

        public ProjectCommentViewModel GetProjectComment(int id)
        {
            var projectComment = _dbContext.ProjectComments
                .Include(pr => pr.Project)
                .Include(u => u.User)
                .SingleOrDefault(p => p.Id == id);

            if (projectComment == null)
            {
                return null;
            }

            var projectCommentViewAllModel = new ProjectCommentViewModel(
                    projectComment.Id,
                    projectComment.Content,
                    projectComment.Project.Title,
                    projectComment.User.FullName
                );

            return projectCommentViewAllModel;
        }

        public void Update(UpdateProjectCommentInputModel inputModel)
        {
            var projectComment = _dbContext.ProjectComments.SingleOrDefault(p => p.Id == inputModel.Id);

            projectComment.Update(inputModel.Content);
            _dbContext.SaveChanges();
        }
    }
}
