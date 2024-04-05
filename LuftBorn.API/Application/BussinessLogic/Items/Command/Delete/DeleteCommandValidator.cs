using FluentValidation;

namespace Application.BussinessLogic.Items.Command.Delete
{
    public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty().NotNull().WithMessage("Id is Required");
        }
    }
}
