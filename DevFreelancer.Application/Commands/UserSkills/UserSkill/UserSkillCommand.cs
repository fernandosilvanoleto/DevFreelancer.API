using MediatR;

namespace DevFreelancer.Application.Commands.UserSkills.UserSkillCommand
{
    public class UserSkillCommand : IRequest<int>
    {
        public int IdUser { get; set; }
        public int IdSkill { get; set; }
    }
}
