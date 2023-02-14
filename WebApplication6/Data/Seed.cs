using Microsoft.AspNetCore.Identity;

namespace WebApplication6.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<IdentityUser> user, RoleManager<IdentityRole> roleManager)
        {

            if (!user.Users.Any())
            {
                var users = new List<IdentityUser>
                {
                    new IdentityUser { UserName = "Arun" },
                    new IdentityUser { UserName = "Binod" },
                    new IdentityUser { UserName = "Kanakal" }

                };

                int count = 0;
                foreach (var item in users)
                {
                    var userCreated = await user.CreateAsync(item, "Pa$$w0rd");
                    if (userCreated.Succeeded)
                    {
                        if (count == 1)
                        {
                            await user.AddToRoleAsync(item, "Admin");
                        }

                        else if(count == 2)
                        {
                            await user.AddToRoleAsync(item, "SubAdmin");
                        }
                        else
                        {
                            await user.AddToRoleAsync(item, "User");
                        }
                    }
                    count++;
                }
            }

            if (!roleManager.Roles.Any())
            {
                var roles = new List<IdentityRole>
                {
                    new IdentityRole {Name = "Admin"},
                    new IdentityRole {Name = "SubAdmin"},
                    new IdentityRole {Name = "User"}
                };

                foreach (var item in roles)
                {
                    await roleManager.CreateAsync(item);
                }

            }

            context.SaveChangesAsync();
        }
    }
}
