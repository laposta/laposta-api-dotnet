using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laposta.Services
{
    public static class LapostaUtil
    {
        public static string convertBool(bool? value)
        {
            if (value == false || value == null)
            {
                return "false";
            }

            return "true";
        }
    }
}