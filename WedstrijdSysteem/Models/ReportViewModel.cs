using System;
using System.ComponentModel.DataAnnotations;

namespace WedstrijdSysteem.Models
{
    public class ReportViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Report { get; set; }
    }
}
