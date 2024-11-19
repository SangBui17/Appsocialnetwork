using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Repository
{
    interface FriendResquestRepository
    {
        Task<bool> addFriendResquest(long id);
        Task<bool> removeFriendRequest(long id);
        Task<List<FriendRequestResponse>> getAllFriendRequest();


    }
}
