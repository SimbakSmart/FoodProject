using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {

        public static async Task Initializae(DbFoodContext context, UserManager<User> userManager)
        {

            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "bob",
                    Email = "bob@smart.com"
                };

                await userManager.CreateAsync(user, "12345678");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@smart.com"
                };

                await userManager.CreateAsync(admin, "12345678");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
            }

        }
    }
}
