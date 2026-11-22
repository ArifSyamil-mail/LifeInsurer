
using LifeInsurer.Api.Enums;
using LifeInsurer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeInsurer.Api.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Only create demo users if the Users table is empty.
        if (await context.Users.AnyAsync())
        {
            return;
        }

        var users = new List<User>
        {
            new User
            {
                FullName = "Demo Claimant",
                Email = "claimant@lifeinsurer.test",
                Role = UserRole.Claimant
            },

            new User
            {
                FullName = "Demo Claim Officer",
                Email = "officer@lifeinsurer.test",
                Role = UserRole.ClaimOfficer
            },

            new User
            {
                FullName = "Demo Claim Approver",
                Email = "approver@lifeinsurer.test",
                Role = UserRole.ClaimApprover
            }
        };

        context.Users.AddRange(users);

        await context.SaveChangesAsync();
    }
}
