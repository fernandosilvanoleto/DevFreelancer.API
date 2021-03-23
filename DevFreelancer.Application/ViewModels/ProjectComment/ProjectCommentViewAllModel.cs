using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Application.ViewModels.ProjectComment
{
    public class ProjectCommentViewAllModel
    {
        public ProjectCommentViewAllModel(int id, string content, string nameProject, string nameUser, DateTime createdAt)
        {
            Id = id;
            Content = content;
            NameProject = nameProject;
            NameUser = nameUser;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public string Content { get; private set; }
        public string NameProject { get; private set; }
        public string NameUser { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
