namespace Caesar.Application.Aggregates.Customers.Commands.CreateCustomer;

using AutoMapper;
using Caesar.Application.Interfaces;
using Caesar.Domain.Entities;
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
        var user = this._mapper.Map<CreateCustomerCommand, User>(request);
        this._caesarDbContext.Users.Add(user);
        await this._caesarDbContext.SaveChangesAsync(cancellationToken);
        await this._stripeService.CreateCustomer(request.Name, request.Description, request.Phone, request.Email);
        return user.Id;
    }
}
