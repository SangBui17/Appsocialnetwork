using Social_network.Models;
using Social_network.request;
using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Repository
{
    interface MessageRepository
    {
        Task<List<MessageResponse>> getAllMessageByMeAndUserId(PageInfo pageInfo, long userTarget);
        string creatMessage(MessageRequest messageRequest, string userTarget);
        string deleteMessage(long messageID);
        Task<List<MessageResponse>> getAlluserMessageByme(PageInfo pageInfo);
    }
}
