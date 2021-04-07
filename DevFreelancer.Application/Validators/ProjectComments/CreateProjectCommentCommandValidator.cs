using DevFreelancer.Application.Commands.ProjectComments.CreateComment;
using FluentValidation;

namespace DevFreelancer.Application.Validators.ProjectComments
{
    public class CreateProjectCommentCommandValidator : AbstractValidator<CreateProjectCommentCommand>
    {
        public CreateProjectCommentCommandValidator()
        {
            RuleFor(pc => pc.Content)
                .MaximumLength(1000)
                .WithMessage("Tamanho máximo do Comentário é de 1.000 caracteres.");
        }
    }
}
