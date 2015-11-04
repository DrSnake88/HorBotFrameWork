using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HorBotFrameWork.Core;

namespace HorBotFrameWork.Web
{
    public static class Extract
    {
        // Get the source code of the passed document
        public static string Document(Uri url)
        {
            var document = "";

            if (HTTP.Request == null) HTTP.OpenRequest(url);
            HTTP.OpenResponse();
            
            document = new StreamReader(HTTP.Response.GetResponseStream(), Encoding.ASCII).ReadToEnd(); // Get the source code of the passed page

            return document;
        }

        #region Paragraphs
        public static List<string> Paragraphs(Uri url)
        {
            var document = Document(url);
            var paragraphs = Utility.GetBetween(document, new string[] { "<p>", "</p>"} );

            return paragraphs;
        }

        public static List<string> Paragraphs(string input)
        {
            var paragraphs = Utility.GetBetween(input, new string[] {"<p>", "</p>"});

            return paragraphs;
        }
        #endregion

        #region Spans
        public static List<string> Spans(Uri url)
        {
            var document = Document(url);
            var paragraphs = Utility.GetBetween(document, new[] { "<span>", "</span>" });

            return paragraphs;
        }

        public static List<string> Spans(string input)
        {
            var paragraphs = Utility.GetBetween(input, new[] { "<span>", "</span>" });

            return paragraphs;
        }
        #endregion

        #region Images
        public static List<Image> Images(Uri url)
        {
            var document = Document(url);
            var links = Utility.GetLinks(document);
            var images = new List<Image>();

            foreach (var link in links)
            {
                try
                {
                    var image = new Image(url + link);
                    images.Add(image);
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return images;
        }

        public static List<Image> Images(string input)
        {
            var links = Utility.GetLinks(input);
            var images = new List<Image>();

            foreach (var link in links)
            {
                try
                {
                    var image = new Image(link);
                    images.Add(image);
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return images;
        }
        #endregion

    }
}
