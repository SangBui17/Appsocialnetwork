using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class Role : BaseEntity
    {
        public string name { get; set; }
        public List<User> user { get; set; } = new List<User>();
    }
}
