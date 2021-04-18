using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace AbschlussprojektIHK
{
    //class for the JSON logic
    class JSON
    {
        static public User DeserializeUser()
        {
            var json = File.ReadAllText(@"appsettings.json");
            return _ = JsonConvert.DeserializeObject<User>(json);
        }
        static public void SerializeUser(User user)
        {
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(@"appsettings.json", json);
        }
        static public void ChangeUserIsOnline(User user)
        {
            user.UserIsOnline = !user.UserIsOnline;
            var json = JsonConvert.SerializeObject(user);
            File.WriteAllText(@"appsettings.json", json);
        }
        static public User ReadJSON()
        {
            JObject json = JObject.Parse(File.ReadAllText(@"appsettings.json"));
            using (StreamReader file = File.OpenText(@"appsettings.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
            }
        }
        static public void WriteJSON()
        {
            
        }
    }
}
