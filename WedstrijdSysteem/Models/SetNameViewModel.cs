using System;
using System.ComponentModel.DataAnnotations;

namespace WedstrijdSysteem.Models
{
    public class SetNameViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(maximumLength: 12, ErrorMessage = "Username may only a maximum container 12 characters")]
        public string Username { get; set; }
    }
}
