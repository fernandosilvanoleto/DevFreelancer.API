using DevFreelancer.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;

            CreatedAt = DateTime.Now;
            Active = true;

            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }

        // TERÁ UMA LISTA DE SKILLS, POIS O RELACIONAMENTO DE USER PARA SKILL É DE MUITO PARA MUITO (N X N)
        // ALÉM DE UMA TABELA NO MEIO COM NOME DE USERSKILL, AQUI NO USER TERÁ ESSA LISTA, ASSIM COMO EM SKILL
        public List<UserSkill> Skills { get; private set; }

        // UM USER PODE SER DONO DE UM PROJETO
        public List<Project> OwnedProjects { get; private set; }

        // UM USER PODE SER UM FREELANCER/EXECUTOR DO PROJETO
        // RELACIONAMENTO PARA 1 PARA N COM O Project
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Update(string fullName, string email, bool active)
        {
            this.FullName = fullName;
            this.Email = email;
            this.Active = active;
        }

    }
}
