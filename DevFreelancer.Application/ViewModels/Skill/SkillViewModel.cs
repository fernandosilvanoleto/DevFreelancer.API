using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Application.ViewModels
{
    public class SkillViewModel
    {
        public SkillViewModel(int id, string description)
        {
            Id = id;
            Description = description;
        }
        public int Id { get; private set; }
        public string Description { get; private set; }
    }
}
