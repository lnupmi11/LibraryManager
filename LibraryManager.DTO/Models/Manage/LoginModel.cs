using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.DTO.Models.Manage
{
    class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
