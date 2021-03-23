using System;

namespace DevFreelancer.Application.ViewModels.ProjectComment
{
    public class ProjectCommentViewModel
    {
        public ProjectCommentViewModel(int id, string content, string nameProject, string nameUser)
        {
            Id = id;
            Content = content;
            NameProject = nameProject;
            NameUser = nameUser;
        }

        public int Id { get; private set; }
        public string Content { get; private set; }
        public string NameProject { get; private set; }
        public string NameUser { get; private set; }
    }
}
