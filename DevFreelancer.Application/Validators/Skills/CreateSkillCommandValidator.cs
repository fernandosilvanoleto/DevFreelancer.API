using DevFreelancer.Application.Commands.Skills.CreateSkill;
using FluentValidation;

namespace DevFreelancer.Application.Validators.Skills
{
    public class CreateSkillCommandValidator  : AbstractValidator<CreateSkillCommand>
    {
        public CreateSkillCommandValidator()
        {
            RuleFor(skill => skill.Description)
                .MaximumLength(100)
                .WithMessage("Tamanho máximo de Descrição é de 100 caracteres.");
        }
    }
}
