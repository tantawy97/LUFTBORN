using FluentValidation;

namespace Application.BussinessLogic.Items.Command.Add
{
    public class AddCommandValidator : AbstractValidator<AddCommand>
    {
        public AddCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().NotNull().WithMessage("Name is Required");

            RuleFor(e => e.Price)
           .NotNull().WithMessage("Price is required");

            RuleFor(e => e.Quantity)
          .NotNull().WithMessage("Quantity is required");
        }
    }
}
