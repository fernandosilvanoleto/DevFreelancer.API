using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description)
        {
            Description = description;

            CreatedAt = DateTime.Now;

            Skills = new List<UserSkill>();
        }

        public string Description  { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public List<UserSkill> Skills { get; private set; }
    }
}
