using DevFreelancer.Application.ViewModels.Skill;
using MediatR;

namespace DevFreelancer.Application.Queries.Skills.GetSkillById
{
    public class GetSkillByIdQuery : IRequest<SkillViewDetailsModel>
    {
        public int Id { get; private set; }

        public GetSkillByIdQuery(int id)
        {
            Id = id;
        }
    }
}
