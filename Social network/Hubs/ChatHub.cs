
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Social_network.Hubs
//{
//    internal class ChatHub : Hub
//    {

//        public async Task Joinchat(long userTarget, string message)
//        {
//            await Clients.All.SendAsync("ReceiveMessage", userTarget, message);
//        }
//    }
//}
