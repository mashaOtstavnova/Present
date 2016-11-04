using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Presents.Core.Domain;
using VKontakte;
using VKontakte.API;
using VKontakte.API.Methods;
using VKontakte.API.Models;
using VKontakte.API.Photos;
using VKontakte.Dialogs;
using Path = Android.Graphics.Path;

namespace Presents.Droid.Services
{
    public static class GetProfileService
    {
        public static async Task<User> GetUsers()
        {
            var request = VKApi.Users.Get(new VKParameters(new Dictionary<string, Java.Lang.Object> { {
                        VKApiConst.Fields,
                        "id,first_name,last_name,sex,bdate,city,country,photo_50,photo_max_orig"
                    }
                }));
            try
            {
                var response = await request.ExecuteAsync();
                var json = JObject.Parse(response.Json.ToString());
                var jsonArray = (JArray)json["response"];
                return JsonConvert.DeserializeObject<User>(jsonArray[0].ToString());
            }
            catch (Exception ex)
            {
                var c = ex.Message;
                return null;
            }
        }
    }
}