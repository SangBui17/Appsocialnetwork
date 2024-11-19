using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class Friend : BaseEntity
    {
        public User user {  get; set; }
    }
}
