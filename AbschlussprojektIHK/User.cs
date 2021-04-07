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
        [JsonProperty("UserIsOnline")]
        public string EmailUser { get; set; }
        [JsonProperty("UserIsOnline")]
        public string PasswordUser { get; set; }
        public User() { }
        public User(string _firstname, string _familyname, string _mailOfInstructor, bool _userIsOnline, string _emailUser, string _passwordUser)
        {
            Firstname = _firstname;
            Familyname = _familyname;
            MailOfInstructor = _mailOfInstructor;
            UserIsOnline = _userIsOnline;
            EmailUser = _emailUser;
            PasswordUser = _passwordUser;
        }
    }
}
