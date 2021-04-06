using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace AbschlussprojektIHK
{
    class JSON
    {
        public static User DeserializeUser()
        {
            User user = new User();
            var json = File.ReadAllText(@"User.json");
            return user = JsonConvert.DeserializeObject<User>(json);
        }
        static public void SerializeUser(User user)
        {
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(@"User.json", json);
        }
        static public void ChangeUserIsOnline(User user)
        {
            user.UserIsOnline = !user.UserIsOnline;
            var json = JsonConvert.SerializeObject(user);
            File.WriteAllText(@"User.json", json);
        }
    }
}
