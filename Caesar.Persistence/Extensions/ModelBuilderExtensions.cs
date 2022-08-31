namespace Caesar.Persistence.Extensions
{
    using System;
    using Common.Helpers;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Users

            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Id = 1,
                    DateOfBirth = new DateTime(1998, 9, 8),
                    Email = "defytest@mailinator.com",
                    Phone = "+375201112233",
                    Password = CryptoHelper.HashPassword("Qwerty123"),
                    Name = "test user",
                    Description = "testdesc",
                    CustomerStripeId = "cus_MLaop30pGoQG5M"
                });

            #endregion
        }
    }
}
