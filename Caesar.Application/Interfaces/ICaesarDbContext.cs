namespace Caesar.Application.Interfaces;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public interface ICaesarDbContext
{
    DbSet<User> Users
    {
        get;
        set;
    }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
