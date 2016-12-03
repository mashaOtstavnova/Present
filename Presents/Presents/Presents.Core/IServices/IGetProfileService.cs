using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presents.Core.Domain;

namespace Presents.Core.IServices
{
    public interface IGetProfileService
    {
        Task<User> GetUsers();
        Task<Friends> GetFriends();
        Task<Friend> GetFriend(int idFriend);

    }
}
