namespace Caesar.Application.Aggregates.Customers.Commands.SignUp
{
    using FluentValidation;

    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Phone).NotEmpty();
        }
    }
}
