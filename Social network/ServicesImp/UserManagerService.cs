using IdentityModel.Client;
using IdentityModel.OidcClient;
using Social_network.Models;
using Social_network.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.ServicesImp
{
    class UserManagerService : UserManagerRepository
    {

        readonly UserManager _userManager;
        public async Task<ClaimsPrincipal> GetAuthenticatedUser()
        {
            ClaimsPrincipal user = null;
            var idToken = await SecureStorage.Default.GetAsync("id_token");

            if (idToken != null)
            {
                var doc = await new HttpClient().GetDiscoveryDocumentAsync("https://10.0.2.2:2711/auth/login");
                var validator = new JwtHandlerIdentityTokenValidator();
                var options = new OidcClientOptions
                {
                    
                    ClientId = _userManager._clientId,
                    ProviderInformation = new ProviderInformation
                    {
                        IssuerName = doc.Issuer,
                        KeySet = doc.KeySet
                    }
                };

                var validationResult = await validator.ValidateAsync(idToken, options);

                if (!validationResult.IsError) user = validationResult.User;
            }

            return user;
        }
    }
}
