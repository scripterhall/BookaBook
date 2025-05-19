using BookaBook.Models;
using Microsoft.AspNetCore.Identity;

namespace BookaBook.Service
{
        public class DbInitializer
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly UserManager<ApplicationUser> _userManager;

            public DbInitializer(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
            {
                _roleManager = roleManager;
                _userManager = userManager;
            }

            public async Task SeedRolesAndAdminAsync()
            {
                string[] roles = { "Admin", "User" };
                foreach (var role in roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                        await _roleManager.CreateAsync(new IdentityRole(role));
                }

                // Créer un compte admin si absent
                string adminEmail = "root@root.root";
                string adminPassword = "Azer369*";

                var admin = await _userManager.FindByEmailAsync(adminEmail);
                if (admin == null)
                {
                    var newAdmin = new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true,
                        FirstName = "Root",
                        LastName = "Admin"
                    };

                    var result = await _userManager.CreateAsync(newAdmin, adminPassword);
                    if (result.Succeeded)
                        await _userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }
}
