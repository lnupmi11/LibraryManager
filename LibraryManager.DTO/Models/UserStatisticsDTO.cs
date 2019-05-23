using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models
{
    public class UserStatisticsDTO
    {
        public Dictionary<string, int> ReadBooksByGenreCount { get; set; }
    }
}
