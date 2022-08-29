namespace DefyED.Application.Aggregates.Users.Queries.GetClientById;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Caesar.Application.Aggregates.Customers.Queries.GetClientById;
using Caesar.Application.Exceptions;
using Caesar.Application.Infrastructure.Abstracts;
using Caesar.Application.Interfaces;
using Caesar.Application.Models;
using Caesar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class GetClientByIdQueryHandler
    : AbstractHandler<GetClientByIdQuery, Customer>
{
    public GetClientByIdQueryHandler(ICaesarDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
        : base(dbContext, mapper, currentUserService)
    {
    }

    public override async Task<Customer> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var client = await this._dbContext.Users
            .Where(x => request.Id.Equals(x.Id))
            .ProjectTo<Customer>(this._mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (client == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        return client;
    }
}
