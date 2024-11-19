using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class Follower : BaseEntity
    {
        public User user {  get; set; }
    }
}
