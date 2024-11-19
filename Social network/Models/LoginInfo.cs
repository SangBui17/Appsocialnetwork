using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    public class LoginInfo
    {
        public string token { get; set; }
        public List<string> role { get; set; }  // Thay đổi từ string thành List<string>
        public string username { get; set; }

    }
}
