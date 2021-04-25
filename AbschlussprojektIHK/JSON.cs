using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace AbschlussprojektIHK
{
    //class for JSON logic
    class JSON
    {
        static public User ReadUser()
        {
            //File.Decrypt("User.json");
            var json = File.ReadAllText("User.json");
            //File.Encrypt("User.json");
            return _ = JsonConvert.DeserializeObject<User>(json);
        }
        static public Appsettings ReadAppsettings()
        {
            var json = File.ReadAllText("Appsettings.json");
            return _ = JsonConvert.DeserializeObject<Appsettings>(json);
        }
        static public void WriteUser(User user)
        {
            //File.Decrypt("User.json");
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText("User.json", json);
            //File.Encrypt("User.json");
        }
        static public void ChangeAppsettingsIsOnline(Appsettings appsettings)
        {
            appsettings.UserIsOnline = !appsettings.UserIsOnline;
        }
    }
}
