using DevFreelancer.Application.ViewModels.UserSkill;
using MediatR;

namespace DevFreelancer.Application.Queries.UserSkill.GetUserSkillById
{
    public class GetUserSkillByIdQuery : IRequest<UserSkillViewModel>
    {
        public GetUserSkillByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
