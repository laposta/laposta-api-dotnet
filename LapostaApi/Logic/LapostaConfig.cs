using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laposta
{
    public static class LapostaConfig
    {
        public const string API_VERSION = "2.0";
        public const string WRAPPER_VERSION = "1.0";
        public const string API_BASE_URI = "api.laposta.nl/v2";
        public static string apiKey { get; set; }
        private static Boolean _https = true;
        public static Boolean https 
        {
            get
            {
                return _https;
            }
            set 
            {
                _https = value;
            }
        }
    }
}