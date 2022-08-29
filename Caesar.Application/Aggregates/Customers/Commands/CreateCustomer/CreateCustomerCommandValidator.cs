namespace Caesar.Application.Aggregates.Customers.Commands.CreateCustomer;

using FluentValidation;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        this.RuleFor(x => x.Name).NotEmpty();

        this.RuleFor(x => x.Email).NotEmpty().EmailAddress();

        this.RuleFor(x => x.Phone).NotEmpty();
    }
}
