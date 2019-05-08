using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.DTO.Models.Manage
{
    public class EditBookViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Rating")]
        public double Rating { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Number of page")]
        public int NumberOfPages{ get; set; }
    }
}
