using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Services
{
    interface LoginRepository
    {
        Task<LoginInfo> Login(string username, string password);
        string Logout();
    }
}
