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
}
