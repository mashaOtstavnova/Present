using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Java.Lang;
using MvvmCross.Platform.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Presents.Core.Domain;
using Presents.Core.IServices;
using VKontakte.API;
using Exception = System.Exception;

namespace Presents.Droid.Services
{
    public class GetProfileService : IGetProfileService
    {
        public async Task<User> GetUsers()
        {
            var request = VKApi.Users.Get(new VKParameters(new Dictionary<string, Object>
            {
                {
                    VKApiConst.Fields,
                    "id,first_name,last_name,sex,bdate,city,country,photo_50,photo_max_orig"
                }
            }));
            try
            {
                var response = await request.ExecuteAsync();
                var json = JObject.Parse(response.Json.ToString());
                var jsonArray = (JArray) json["response"];
                return JsonConvert.DeserializeObject<User>(jsonArray[0].ToString());
            }
            catch (Exception ex)
            {
                var c = ex.Message;
                return null;
            }
        }

        public async Task<Friends> GetFriends()
        {
            var request = VKApi.Friends.Get(new VKParameters(new Dictionary<string, Object>
            {
                {VKApiConst.Fields, "id,first_name,last_name,sex,bdate,city,photo_50,photo_max_orig"}
            }));
            try
            {
                var response = await request.ExecuteAsync();
                var s = response.Json.ToString();
                var json = JObject.Parse(response.Json.ToString());
                var jsonArray = json["response"];
                
                return JsonConvert.DeserializeObject<Friends>(jsonArray.ToString());
            }
            catch (Exception ex)
            {
                var c = ex.Message;
                return null;
            }
        }

        public async Task<Friend> GetFriend (int idFriend)
        {
            var listFriend = await GetFriends();
            return listFriend.items.FirstOrDefault(t => t.id == idFriend);

            throw new System.NotImplementedException();
        }
    }
}