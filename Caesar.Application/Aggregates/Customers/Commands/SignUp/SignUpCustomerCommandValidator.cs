namespace Caesar.Application.Aggregates.Customers.Commands.SignUp
{
    using FluentValidation;

    public class SignUpCustomerCommandValidator : AbstractValidator<SignUpCustomerCommand>
    {
        public SignUpCustomerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Phone).NotEmpty();
        }
    }
}
