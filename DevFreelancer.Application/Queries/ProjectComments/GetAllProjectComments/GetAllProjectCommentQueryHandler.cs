using DevFreelancer.Application.ViewModels.ProjectComment;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Queries.ProjectComments.GetAllProjectComments
{
    public class GetAllProjectCommentQueryHandler : IRequestHandler<GetAllProjectCommentQuery, List<ProjectCommentViewAllModel>>
    {
        private readonly DevFreelancerDbContext _dbContext;
        public GetAllProjectCommentQueryHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProjectCommentViewAllModel>> Handle(GetAllProjectCommentQuery request, CancellationToken cancellationToken)
        {
            var projectComments = _dbContext.ProjectComments;

            var projectCommentViewAllModel = await projectComments
                .Include(pr => pr.Project)
                .Include(u => u.User)
                .Select(pc => new ProjectCommentViewAllModel(pc.Id, pc.Content, pc.Project.Title, pc.User.FullName, pc.CreatedAt))
                .ToListAsync();

            return projectCommentViewAllModel;
        }
    }
}
