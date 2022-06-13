using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace eShop.IdentityServer.Configuration;
public class IdentityConfiguration
{
    public const string Admin = "Admin";
    public const string Client = "Client";

    public static IEnumerable<IdentityResource> IdentityResources =>
      new List<IdentityResource>
      {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
      };

    public static IEnumerable<ApiScope> ApiScopes =>
      new List<ApiScope>
      {
                // eShop is the web application to access
                // o IdentityServer to get token
                new ApiScope("eShop", "eShop Server"),
                new ApiScope(name: "read", "Read data."),
                new ApiScope(name: "write", "Write data."),
                new ApiScope(name: "delete", "Delete data."),
      };

    public static IEnumerable<Client> Clients =>
       new List<Client>
       {
               //generic Client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("abracadabra#simsalabim".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials, //need user credentials
                    AllowedScopes = {"read", "write", "profile" }
                },
                new Client
                {
                    ClientId = "eShop",
                    ClientSecrets = { new Secret("abracadabra#simsalabim".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code, //by code
                    RedirectUris = {"https://localhost:7165/signin-oidc"},//login
                    PostLogoutRedirectUris = {"https://localhost:7165/signout-callback-oidc"},//logout
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "eShop"
                    }
                }
       };

}
