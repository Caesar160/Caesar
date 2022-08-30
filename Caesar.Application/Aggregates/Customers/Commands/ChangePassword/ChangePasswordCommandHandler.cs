namespace Caesar.Application.Aggregates.Customers.Commands.ChangePassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caesar.Application.Interfaces;
using Constants.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class ChangePasswordCommandHandler
    : IRequestHandler<ChangePasswordCommand>
{
    private readonly ICaesarDbContext dbContext;

    private readonly ICurrentUserService currentUser;

    public ChangePasswordCommandHandler(ICaesarDbContext dbContext, ICurrentUserService currentUser)
    {
        this.dbContext = dbContext;
        this.currentUser = currentUser;
    }

    public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await this.dbContext.Users
            .FirstAsync(x => x.Id == this.currentUser.UserId, cancellationToken);

        user.Password = CryptoHelper.HashPassword(request.Password);
        this.dbContext.Users.Update(user);
        await this.dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
