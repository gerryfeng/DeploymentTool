using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public static class OAuthConfig
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("pdApi", "Panda API")
                {
                    Scopes = { "pdApi" }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("pdApi")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "pdClient",
                    AllowedGrantTypes = new List<string>()
                    {
                        GrantTypes.ResourceOwnerPassword.FirstOrDefault(),
                    },
                    ClientSecrets =
                    {
                        new Secret("pdSecret".Sha256())
                    },
                    AllowedScopes = { "pdApi" },
                    AccessTokenLifetime = 36000,
                }
            };


        public static List<TestUser> TestUsers => 
            new List<TestUser>
            {
                new TestUser()
                {
                     SubjectId = "1",
                     Username = "pdUser",
                     Password = "pdPwd"
                }
            };
    }
}
