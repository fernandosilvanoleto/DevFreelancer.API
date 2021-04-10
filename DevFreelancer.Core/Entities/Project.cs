using DevFreelancer.Core.Enums;
using System;
using System.Collections.Generic;

namespace DevFreelancer.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost, DateTime finishedAt)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
            FinishedAt = finishedAt;

            CreatedAt = DateTime.Now;
            Comments = new List<ProjectComment>();
            Status = ProjectStatusEnum.Created;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }

        // RELACIONAMENTO ENTRE USER E PROJETCT É 1 x N [User] 1 => N[Project]
        public int IdClient { get; private set; }

        // ATRIBUTO DE NAVEGAÇÃO => usado em dbcontext
        public User Client { get; private set; }

        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }

        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // ? = QUANDO INICAR PROJETO, POSSO NÃO SETAR ESSE VALOR
        public DateTime? StartedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if(Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.InProgress)
                Status = ProjectStatusEnum.Cancelled;
        }

        public void Start()
        {
            if(Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }            
        }

        public void Finish()
        {
            if(Status == ProjectStatusEnum.Created || Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended)
            {
                Status = ProjectStatusEnum.InProgress;
                FinishedAt = DateTime.Now;
            }
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
