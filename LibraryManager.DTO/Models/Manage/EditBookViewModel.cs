using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.DTO.Models.Manage
{
    public class EditBookViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "AuthorName")]
        public string AuthorName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "AuthorSSurame")]
        public string AuthorSurname { get; set; }

        //[Required]
        //[Display(Name = "Genres")]
        //public SelectList Genres { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Number of page")]
        public int NumberOfPages{ get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Rating")]
        public double Rating { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public int Year { get; set; }

        //[Required]
        //[DataType(DataType.Text)]
        //[Display(Name = "Selected Genre")]
        //public string SelectedGenre { get; set; }
    }
}
