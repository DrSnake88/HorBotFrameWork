using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorBotFrameWork.Web
{
    public static class Extract
    {
        // Get the source code of the passed document
        public static string Document(string url)
        {
            var document = "";

            if (HTTP.Request == null) HTTP.OpenRequest(url);
            HTTP.OpenResponse();
            
            document = new StreamReader(HTTP.Response.GetResponseStream(), Encoding.ASCII).ReadToEnd(); // Get the source code of the passed page

            return document;
        }

        public static List<string> Paragraphs(string url)
        {
            var document = Document(url);
            var paragraphs = Utility.GetBetween(document, new string[] { "<p>", "</p>"} );

            return paragraphs;
        }
    }
}
