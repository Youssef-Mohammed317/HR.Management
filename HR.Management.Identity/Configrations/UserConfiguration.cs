using HR.Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Management.Identity.Configrations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = "AQAAAAIAAYagAAAAEH8P8dqvqWkN5J5YxLdWC2D/0HMm+1cOUjqYzMcL+aLMJ5PU9SL7d1Jz5Wz8aA==",
                    EmailConfirmed = true,
                    SecurityStamp = "JKLMNOPQRSTUVWXYZABCDEFGHI",
                    ConcurrencyStamp = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                new ApplicationUser
                {
                    Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    PasswordHash = "AQAAAAIAAYagAAAAEJdMJ5fQ7rPnF8VL+8QKqT4N/kJ8L6mJ5P+zL8SJ6fQ8m9d+L4JzK5d8aA==",
                    EmailConfirmed = true,
                    SecurityStamp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                    ConcurrencyStamp = "9e224968-33e4-4652-b7b7-8574d048cdb9"
                }
            );
        }

    }
}
