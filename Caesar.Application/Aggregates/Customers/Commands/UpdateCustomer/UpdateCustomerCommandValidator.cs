namespace Caesar.Application.Aggregates.Customers.Commands.UpdateCustomer;

using CreateCustomer;
using FluentValidation;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        this.RuleFor(x => x.Name).NotEmpty();

        this.RuleFor(x => x.Description).NotEmpty();
    }
}
