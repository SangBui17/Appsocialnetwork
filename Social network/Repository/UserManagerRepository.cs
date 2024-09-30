using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Services
{
    interface UserManagerRepository
    {
        Task<ClaimsPrincipal> GetAuthenticatedUser();
    }
}
