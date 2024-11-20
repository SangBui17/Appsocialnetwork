using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Repository
{
    internal interface FriendResquestRepository
    {
        Task<bool> AddFriendResquest(long id);
        Task<bool> RemoveFriendRequest(long id);
        Task<List<FriendRequestResponse>> getAllFriendRequest();
    }
}
