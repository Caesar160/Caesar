namespace Caesar.Application.Aggregates.Customers.Commands.UpdateCustomer;

using AutoMapper;
using Caesar.Application.Aggregates.Customers.Commands.CreateCustomer;
using Caesar.Application.Interfaces;
using Caesar.Domain.Entities;
using MediatR;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, long>
{
    private readonly ICaesarDbContext _caesarDbContext;
    private readonly IStripeService _stripeService;
    private readonly IMapper _mapper;
    private readonly long userId;

    public UpdateCustomerCommandHandler(IStripeService stripeService, IMapper mapper, ICaesarDbContext caesarDbContext, ICurrentUserService currentUser)
    {
        this._stripeService = stripeService;
        this._mapper = mapper;
        this._caesarDbContext = caesarDbContext;
        this.userId = currentUser.UserId;
    }

    public async Task<long> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var user = this._caesarDbContext.Users.FirstOrDefault(x => x.Id == this.userId);
        user = this._mapper.Map<UpdateCustomerCommand, User>(request);
        this._caesarDbContext.Users.Update(user);
        await this._caesarDbContext.SaveChangesAsync(cancellationToken);
        await this._stripeService.UpdateCustomer(user.StripeId, request.Name, request.Description);
        return user.Id;
    }
}
