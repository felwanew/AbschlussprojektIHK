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
        static public object DeserializePath(string path)
        {
            var json = File.ReadAllText(path);
            return _ = JsonConvert.DeserializeObject<object>(json);
        }
        static public void SerializePath(User user,string path)
        {
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        static public void ChangeUserIsOnline(User user)
        {
            user.UserIsOnline = !user.UserIsOnline;
            var json = JsonConvert.SerializeObject(user);
            File.WriteAllText(@"User.json", json);
        }
    }
}
