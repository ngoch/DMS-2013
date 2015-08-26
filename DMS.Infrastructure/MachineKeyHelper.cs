using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace DMS.Infrastructure
{
    public static class MachineKeyHelper
    {
        public static string Encrypt(string txt, params string[] purposes)
        {
            var unprotectedBytes = Encoding.UTF8.GetBytes(txt);
            var protectedBytes = MachineKey.Protect(unprotectedBytes, purposes);
            var protectedText = HttpServerUtility.UrlTokenEncode(protectedBytes);
            return protectedText;
        }

        public static string Decrypt(string encryptedValue, params string[] purposes)
        {           
            var protectedBytes =HttpServerUtility.UrlTokenDecode(encryptedValue);
            var unprotectedBytes = MachineKey.Unprotect(protectedBytes, purposes);
            var unprotectedText = Encoding.UTF8.GetString(unprotectedBytes);
            return unprotectedText;
        }
    }
}
