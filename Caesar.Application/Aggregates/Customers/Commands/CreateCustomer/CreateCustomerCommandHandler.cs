namespace Caesar.Application.Aggregates.Customers.Commands.CreateCustomer;

using AutoMapper;
using Interfaces;
using Domain.Entities;
using Common.Helpers;
using MediatR;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, long>
{
    private readonly ICaesarDbContext _caesarDbContext;
    private readonly IStripeService _stripeService;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(IStripeService stripeService, IMapper mapper, ICaesarDbContext caesarDbContext)
    {
        this._stripeService = stripeService;
        this._mapper = mapper;
        this._caesarDbContext = caesarDbContext;
    }

    public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var stripeCustomer = this._stripeService.CreateCustomerAsync(request.Name, request.Description, request.Phone, request.Email).Result;
        var user = this._mapper.Map<CreateCustomerCommand, User>(request);
        user.Password = CryptoHelper.HashPassword(request.Password);
        user.StripeId = stripeCustomer.Id;
        this._caesarDbContext.Users.Add(user);
        await this._caesarDbContext.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
