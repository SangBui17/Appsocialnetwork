using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Social_network.Models
{
    internal class BaseEntity
    {
        public long id {  get; set; }

        public Date createdDate { get; set; }
    }
}
