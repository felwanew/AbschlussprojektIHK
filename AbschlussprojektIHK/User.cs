using Newtonsoft.Json;
using System;

namespace AbschlussprojektIHK
{
    class User : IUser
    {
        [JsonProperty("Firstname")]
        public string Firstname { get; set; }
        [JsonProperty("Familyname")]
        public string Familyname { get; set; }
        [JsonProperty("MailOfInstructor")]
        public string MailOfInstructor { get; set; }
        [JsonProperty("EmailUser")]
        public string EmailUser { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        public User() { }
        public User(string _firstname, string _familyname, string _mailOfInstructor, string _emailUser, string _password)
        {
            Firstname = _firstname;
            Familyname = _familyname;
            MailOfInstructor = _mailOfInstructor;
            EmailUser = _emailUser;
            Password = _password;
        }
    }

    public interface IUser
    {
        string Firstname { get; set; }
        string Familyname { get; set; }
        string MailOfInstructor { get; set; }
        string EmailUser { get; set; }
        string Password { get; set; }
    }
}
