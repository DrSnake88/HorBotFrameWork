using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HorBotFrameWork.Web
{
    public static class HTTP
    {
        public static HttpWebRequest Request { get; set; }
        public static HttpWebResponse Response { get; set; }

        #region Open Connections
        public static void OpenRequest(string url)
        {
            var uri = new Uri(url);
            Request = WebRequest.CreateHttp(uri); // Save a WebRequest to the Request variable
        }

        public static void OpenResponse()
        {
            Response = (HttpWebResponse)Request.GetResponse(); // Get the response of the saved request
        }
        #endregion

        #region Close Connections
        public static void CloseResponse()
        {
            Response.Close(); // Close the response
        }
        #endregion

    }
}
