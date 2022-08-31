namespace Caesar.Application.Aggregates.Customers.Commands.UpdateCustomer;

using AutoMapper;
using Interfaces;
using Domain.Entities;
using MediatR;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, long>
{
    private readonly ICaesarDbContext _caesarDbContext;
    private readonly IStripeService _stripeService;
    private readonly long userId;

    public UpdateCustomerCommandHandler(IStripeService stripeService, ICaesarDbContext caesarDbContext, ICurrentUserService currentUser)
    {
        this._stripeService = stripeService;
        this._caesarDbContext = caesarDbContext;
        this.userId = currentUser.UserId;
    }

    public async Task<long> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var user = this._caesarDbContext.Users.FirstOrDefault(x => x.Id == this.userId);
        user.Name = request.Name;
        user.Description = request.Description;
        this._caesarDbContext.Users.Update(user);
        await this._caesarDbContext.SaveChangesAsync(cancellationToken);
        await this._stripeService.UpdateCustomer(user.CustomerStripeId, request.Name, request.Description);
        return user.Id;
    }
}
