using System;
using System.Net;
using System.Text;

namespace Util
{
    class HTTPBasicAuth
    {
        public static void SetBasicAuthHeader(HttpWebRequest request, String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
        }
    }
}
