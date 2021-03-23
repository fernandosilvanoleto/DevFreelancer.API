using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Application.ViewModels.UserSkill
{
    public class UserSkillViewModel
    {
        public UserSkillViewModel(int id, string nameUser, string nameSkill)
        {
            Id = id;
            NameUser = nameUser;
            NameSkill = nameSkill;
        }

        public int Id { get; private set; }
        public string NameUser { get; private set; }
        public string NameSkill { get; private set; }
    }
}
