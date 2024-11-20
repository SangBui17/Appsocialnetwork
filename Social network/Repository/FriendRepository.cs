using Social_network.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Social_network.Repository
{
    interface FriendRepository
    {
        Task<List<FriendResponse>> GetAllFriends();
        Task<List<FriendResponse>> GetAllFriendId(long userId);
        Task<bool> RemoveFriend(long userId);
        Task<bool> AddFriend(long userId);
    }
}