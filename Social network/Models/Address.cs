using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class Address : BaseEntity
    {
        public string name { get; set; }
        public User userHomeTown {  get; set; }
        public User userCurrentCity {  get; set; }
    }
}
