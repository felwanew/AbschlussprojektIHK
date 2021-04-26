using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AbschlussprojektIHK
{
    class Appsettings
    {
        [JsonProperty("UserIsOnline")]
        public bool UserIsOnline { get; set; }
        public Appsettings() { }
        public Appsettings(bool _userIsOnline)
        {
            UserIsOnline = _userIsOnline;
        }
    }
}
