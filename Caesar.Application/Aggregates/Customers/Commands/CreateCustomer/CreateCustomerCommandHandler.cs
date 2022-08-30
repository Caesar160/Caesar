namespace Caesar.Application.Aggregates.Customers.Commands.CreateCustomer;

using AutoMapper;
using Caesar.Application.Interfaces;
using Caesar.Domain.Entities;
using Constants.Helpers;
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
        await this._stripeService.CreateCustomer(request.Name, request.Description, request.Phone, request.Email);
        var user = this._mapper.Map<CreateCustomerCommand, User>(request);
        user.Password = CryptoHelper.HashPassword(request.Password);
        user.StripeId = this._stripeService.GetCustomerByEmail(request.Email).Result.Id;
        this._caesarDbContext.Users.Add(user);
        await this._caesarDbContext.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
