using System;
using System.ComponentModel.DataAnnotations;

namespace WedstrijdSysteem.Models
{
    public class ClubTeamViewmodel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Club { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Team { get; set; }
    }
}
