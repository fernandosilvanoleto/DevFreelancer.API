using DevFreelancer.Application.ViewModels.ProjectComment;
using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Queries.ProjectComments.GetProjectCommentById
{
    public class GetProjectCommentByIdQueryHandler : IRequestHandler<GetProjectCommentByIdQuery, ProjectCommentViewModel>
    {
        //private readonly DevFreelancerDbContext _dbContext;
        private readonly IProjectCommentRepository _projectCommentRepository;
        public GetProjectCommentByIdQueryHandler(IProjectCommentRepository projectCommentRepository)
        {
            _projectCommentRepository = projectCommentRepository;
        }
        public async Task<ProjectCommentViewModel> Handle(GetProjectCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var projectComment = await _projectCommentRepository.GetProjectCommentByIdAsync(request.Id);

            if (projectComment == null)
            {
                return null;
            }

            var projectCommentViewAllModel = new ProjectCommentViewModel();

            //var projectCommentViewAllModel = new ProjectCommentViewModel(
            //        projectComment.Id,
            //        projectComment.Content,
            //        projectComment.Project.Title,
            //        projectComment.User.FullName
            //    );

            return projectCommentViewAllModel;
        }
    }
}
