using DevFreelancer.Application.InputModels.ProjectComment;
using DevFreelancer.Application.ViewModels.ProjectComment;
using System.Collections.Generic;

namespace DevFreelancer.Application.Services.Interfaces
{
    public interface IProjectCommentService
    {
        ProjectCommentViewModel GetProjectComment(int id);
        List<ProjectCommentViewAllModel> GetAll();
        int Create(CreateProjectCommentInputModel inputModel);
        void Update(UpdateProjectCommentInputModel inputModel);
    }
}
