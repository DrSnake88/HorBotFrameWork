using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorBotFrameWork.Core
{
    public class Image
    {
        public string Path;

        private static readonly string[] ValidExtensions = { "jpg", "bmp", "gif", "png" }; // possible extensions
        

        public Image (string path)
        {
            Path = path;

            if (ValidImage())
            {

            }
            else
            {
                throw new Exception("Not a valid image");
            }
        }

        private bool ValidImage()
        {
            if (ValidExtensions.Any(Path.EndsWith))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
