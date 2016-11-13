using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presents.Core.Domain
{
    public class City
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int sex { get; set; }
        public string bdate { get; set; }
        public City city { get; set; }
        public string photo_50 { get; set; }
        public string photo_max_orig { get; set; }
    }

    public class Users
    {
        public List<User> users { get; set; }
    }
    public class Friend
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int sex { get; set; }
        public string bdate { get; set; }
        public City city { get; set; }
        public string photo_100 { get; set; }
        public int online { get; set; }
        public string deactivated { get; set; }
    }

    public class Friends
    {
        public int count { get; set; }
        public List<Friend> items { get; set; }
       
    }
}
