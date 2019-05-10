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
            var path = @"..\LibraryManager\wwwroot\images\";
            var files = Directory.GetFiles(path);

            return files.Contains(path + imageName);
        }
    }
}
