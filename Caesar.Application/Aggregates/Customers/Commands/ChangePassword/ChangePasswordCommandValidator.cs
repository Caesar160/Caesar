namespace Caesar.Application.Aggregates.Customers.Commands.ChangePassword;

using System.Linq;
using Common.Helpers;
using Constants.Helpers;
using FluentValidation;
using Interfaces;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    private readonly ICaesarDbContext dbContext;

    private readonly ICurrentUserService currentUser;

    public ChangePasswordCommandValidator(ICaesarDbContext dbContext, ICurrentUserService currentUser)
    {
        this.dbContext = dbContext;
        this.currentUser = currentUser;

        this.RuleFor(x => x.OldPassword)
            .Must(this.IsPasswordValid)
            .WithMessage("Old password entered incorrectly. Please, try again");

        this.RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .Must(PasswordsHelper.IsPasswordMeetRequirements)
            .WithMessage(
                "Password must consist of upper and lower case characters, digits, and contain at least 8 characters")
            .NotEqual(x => x.OldPassword)
            .WithMessage("Password has already been used. Please, set a new one");

        this.RuleFor(x => x.Confirm)
            .NotEmpty()
            .Equal(x => x.Password)
            .WithMessage("Your password and confirm password don't match. Please, try again");
    }

    private bool IsPasswordValid(string password)
    {
        var user = this.dbContext.Users.FirstOrDefault(x => x.Id == this.currentUser.UserId);
        return CryptoHelper.VerifyHashedPassword(user.Password, password);
    }
}
