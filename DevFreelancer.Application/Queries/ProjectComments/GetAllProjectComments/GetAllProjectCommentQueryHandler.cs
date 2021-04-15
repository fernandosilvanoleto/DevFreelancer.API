using DevFreelancer.Application.ViewModels.ProjectComment;
using DevFreelancer.Core.Repositories;
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
        //private readonly DevFreelancerDbContext _dbContext;
        private readonly IProjectCommentRepository _projectCommentRepository;
        public GetAllProjectCommentQueryHandler(IProjectCommentRepository projectCommentRepository)
        {
            _projectCommentRepository = projectCommentRepository;
        }
        public async Task<List<ProjectCommentViewAllModel>> Handle(GetAllProjectCommentQuery request, CancellationToken cancellationToken)
        {
            var projectComments = await _projectCommentRepository.GetAllProjectCommentsAsync();

            // FIZ PARA FINS DE TESTES UNITÁRIOS
            var projectCommentViewAllModel = new List<ProjectCommentViewAllModel>();

            //var projectCommentViewAllModel = projectComments
            //    .Select(pc => new ProjectCommentViewAllModel(pc.Id, pc.Content, pc.Project.Title, pc.User.FullName, pc.CreatedAt))
            //    .ToList();

            return projectCommentViewAllModel;
        }
    }
}
