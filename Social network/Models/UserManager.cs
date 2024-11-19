using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    public class UserManager
    {
        public string _domain { get; set; }
        public string _clientId { get; set; }

        public UserManager(string domain, string clientId)
        {
            _domain = domain;
            _clientId = clientId;
        }
    }
}
