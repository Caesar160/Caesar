namespace Caesar.Application.Aggregates.Customers.Queries.GetClientByEmail;

using AutoMapper;
using Constants.Helpers;
using Domain.Entities;
using Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;

public class GetClientByEmailQueryHandler
    : IRequestHandler<GetClientByEmailQuery, Customer>
{
    private readonly ICaesarDbContext dbContext;

    private readonly IMapper mapper;

    public GetClientByEmailQueryHandler(ICaesarDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<Customer> Handle(GetClientByEmailQuery request, CancellationToken cancellationToken)
    {
        var users = await this.dbContext.Users
            .Where(x => x.Email.Trim().ToLower() == request.Email.Trim().ToLower())
            .ToListAsync(cancellationToken);
        var user = users.FirstOrDefault(x => CryptoHelper.VerifyHashedPassword(x.Password, request.Password));
        return await Task.FromResult(this.mapper.Map<User, Customer>(user));
    }
}
