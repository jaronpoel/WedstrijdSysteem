using System;
using System.ComponentModel.DataAnnotations;

namespace WedstrijdSysteem.Models
{
    public class SetEmailViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
