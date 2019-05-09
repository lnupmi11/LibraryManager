using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibraryManager.DTO.Checker
{
    public static class ImageChecker
    {
        public static bool ImageExists(string imageName)
        {
            string[] files = Directory.GetFiles(@"..\LibraryManager\wwwroot\images\");

            return files.Contains(imageName);
        }
    }
}
