using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbschlussprojektIHK
{
    class EmailAddress
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public EmailAddress() { }
        public EmailAddress(string _username, string _password)
        {
            Username = _username;
            Password = _password;
        }
    }
}
