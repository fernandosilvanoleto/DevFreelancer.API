using DevFreelancer.Application.ViewModels.ProjectComment;
using MediatR;
using System.Collections.Generic;

namespace DevFreelancer.Application.Queries.ProjectComments.GetAllProjectComments
{
    public class GetAllProjectCommentQuery : IRequest<List<ProjectCommentViewAllModel>>
    {

    }
}
