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
            var json = File.ReadAllText("User.json");
            return _ = JsonConvert.DeserializeObject<User>(json);
        }
        static public Appsettings ReadAppsettings()
        {
            var json = File.ReadAllText("Appsettings.json");
            return _ = JsonConvert.DeserializeObject<Appsettings>(json);
        }
        static public void WriteUser(User user)
        {
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText("User.json", json);
        }
        static public void ChangeAppsettingsIsOnline(Appsettings appsettings)
        {
            appsettings.UserIsOnline = !appsettings.UserIsOnline;
            //var json = JsonConvert.SerializeObject(appsettings);
            //File.WriteAllText(@"Appsettings.json", json);
        }
    }
}
