using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AbschlussprojektIHK
{
    class Appsettings : IAppsettings
    {
        [JsonProperty("UserIsOnline")]
        public bool UserIsOnline { get; set; }
        public Appsettings() { }
        public Appsettings(bool _userIsOnline)
        {
            UserIsOnline = _userIsOnline;
        }
        public Appsettings(IOptions<Appsettings> options)
        {
            UserIsOnline = options.Value.UserIsOnline;
        }


    }

    internal interface IAppsettings
    {
        bool UserIsOnline { get; set; }
    }
}
