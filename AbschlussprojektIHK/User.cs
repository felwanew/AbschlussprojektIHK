using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AbschlussprojektIHK
{
    class User
    {
        [JsonProperty("Firstname")]
        public string Firstname { get; set; }
        [JsonProperty("Familyname")]
        public string Familyname { get; set; }
        [JsonProperty("MailOfInstructor")]
        public string MailOfInstructor { get; set; }
        [JsonProperty("UserIsOnline")]
        public bool UserIsOnline { get; set; }
        public User() { }
        public User(string _firstname, string _familyname, string _mailOfInstructor, bool _userIsOnline)
        {
            Firstname = _firstname;
            Familyname = _familyname;
            MailOfInstructor = _mailOfInstructor;
            UserIsOnline = _userIsOnline;
        }
        /*static public User LoadUser()
        {
            var json = File.ReadAllText(@"User.json");
            return new User(Convert.ToString(json[0]),
                            Convert.ToString(json[1]),
                            Convert.ToString(json[2]),
                            Convert.ToBoolean(json[3]));
        }*/
    }
}
