using MediatR;

namespace DevFreelancer.Application.Commands.Skills.CreateSkill
{
    public class CreateSkillCommand : IRequest<int>
    {
        public string Description { get; set; }
    }
}
