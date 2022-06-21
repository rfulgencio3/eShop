using eShop.IdentityServer.Configuration;
using eShop.IdentityServer.Data;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace eShop.IdentityServer.SeedDatabase
{
    public class DatabaseIdentityServerInitializer : IDatabaseSeedInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseIdentityServerInitializer(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void InitializeSeedRoles()
        {
            //if Admin profile doesn't exist, so create profile
            if (!_roleManager.RoleExistsAsync(IdentityConfiguration.Admin).Result)
            {
                //create Admin profile
                IdentityRole role = new IdentityRole();
                role.Name = IdentityConfiguration.Admin;
                role.NormalizedName = IdentityConfiguration.Admin.ToUpper();
                _roleManager.CreateAsync(role).Wait();
            }

            //if Client profile doesn't exist, so create profile
            if (!_roleManager.RoleExistsAsync(IdentityConfiguration.Client).Result)
            {
                //create Client profile
                IdentityRole role = new IdentityRole();
                role.Name = IdentityConfiguration.Client;
                role.NormalizedName = IdentityConfiguration.Client.ToUpper();
                _roleManager.CreateAsync(role).Wait();
            }
        }

        public void InitializeSeedUsers()
        {
            //if Admin user doesn't exist, create user and password to assign to profile
            if (_userManager.FindByEmailAsync("admin1@com.br").Result == null)
            {
                //set Admin user data
                ApplicationUser admin = new ApplicationUser()
                {
                    UserName = "admin1",
                    NormalizedUserName = "ADMIN1",
                    Email = "admin1@com.br",
                    NormalizedEmail = "ADMIN1@COM.BR",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    PhoneNumber = "+55 (34) 12345-6789",
                    FirstName = "Usuario",
                    LastName = "Admin1",
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                //create Admin user and set password
                IdentityResult resultAdmin = _userManager.CreateAsync(admin, "Admin123*").Result;
                if (resultAdmin.Succeeded)
                {
                    //include Admin user to Admin profile
                    _userManager.AddToRoleAsync(admin, IdentityConfiguration.Admin).Wait();

                    //include claims to Admin user
                    var adminClaims = _userManager.AddClaimsAsync(admin, new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                        new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                        new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                        new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
                    }).Result;
                }
            }
            //if Client user doesn't exist, create user and password to assign to profile
            if (_userManager.FindByEmailAsync("admin1@com.br").Result == null)
            {
                //set Client user data
                ApplicationUser client = new ApplicationUser()
                {
                    UserName = "client1",
                    NormalizedUserName = "CLIENT1",
                    Email = "client1@com.br",
                    NormalizedEmail = "CLIENT1@COM.BR",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    PhoneNumber = "+55 (34) 12345-6789",
                    FirstName = "Usuario",
                    LastName = "Client1",
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                //create Client user and set password
                IdentityResult resultClient = _userManager.CreateAsync(client, "Client123*").Result;
                if (resultClient.Succeeded)
                {
                    //include Client user to Client profile
                    _userManager.AddToRoleAsync(client, IdentityConfiguration.Admin).Wait();

                    //include claims to Client user
                    var adminClaims = _userManager.AddClaimsAsync(client, new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                        new Claim(JwtClaimTypes.GivenName, client.FirstName),
                        new Claim(JwtClaimTypes.FamilyName, client.LastName),
                        new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
                    }).Result;
                }
            }
        }
    }
}
