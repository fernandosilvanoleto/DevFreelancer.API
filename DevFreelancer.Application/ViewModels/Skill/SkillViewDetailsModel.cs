using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Application.ViewModels.Skill
{
    public class SkillViewDetailsModel
    {
        public SkillViewDetailsModel(string description, DateTime createdAt)
        {
            Description = description;
            CreatedAt = createdAt;
        }

        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
