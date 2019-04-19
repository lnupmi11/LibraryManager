using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LibraryManager.DTO.Models.Manage
{
    class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        [Required]
        [UIHint("password")]
        public string PasswordRepeat { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

    }
}
