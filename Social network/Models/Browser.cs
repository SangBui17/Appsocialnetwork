using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class Browser : BaseEntity
    {
        public User user { get; set; }
        public string ip {  get; set; }
        public string browser {  get; set; }
    }
}
