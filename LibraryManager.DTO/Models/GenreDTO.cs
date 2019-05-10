using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using LibraryManager.DTO.Checker;

namespace LibraryManager.DTO.Models
{
    public class GenreDTO
    {
        public int Id { get; set; }

        public string GenreName { get; set; }
        
        public int NumberOfBooks { get; set; }

        public string ImageName
        {
            get
            {
                if (GenreName == null)
                    return "Default.png";

                var imageName = GenreName + ".png";
                return ImageChecker.ImageExists(imageName) ? imageName : "Default.png";
            }
        }
    }
}
