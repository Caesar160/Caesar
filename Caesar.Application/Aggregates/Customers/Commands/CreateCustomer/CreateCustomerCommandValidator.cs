namespace Caesar.Application.Aggregates.Customers.Commands.CreateCustomer;

using System.Linq;
using Common.Helpers;
using FluentValidation;
using Interfaces;

public class CreateClientCommandValidator
    : AbstractValidator<CreateCustomerCommand>
{
    private readonly ICaesarDbContext dbContext;

    public CreateClientCommandValidator(ICaesarDbContext dbContext)
    {
        this.dbContext = dbContext;

        this.RuleFor(x => x.Email)
            .Must(this.IsEmailUnique).WithMessage("Account already exists. Create a new one or login")
            .EmailAddress().WithMessage("The entered email is invalid")
            .NotEmpty().WithMessage("Email is required");

        this.RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .Must(PasswordsHelper.IsPasswordMeetRequirements)
            .WithMessage(
                "Password must consist of upper and lower case characters, digits, and contain at least 8 characters");

        this.RuleFor(x => x.Phone)
            .Must(this.IsPhoneUnique).WithMessage("Account already exists. Create a new one or login")
            .NotEmpty().WithMessage("Please enter your phone number for registration");
    }

    private bool IsPhoneUnique(string phone)
    {
        return !this.dbContext.Users
            .Any(x => x.Phone.Trim() == phone.Trim());
    }

    private bool IsEmailUnique(string email)
    {
        return !this.dbContext.Users
            .Any(x => x.Email.Trim().ToLower() == email.Trim().ToLower());
    }
}
