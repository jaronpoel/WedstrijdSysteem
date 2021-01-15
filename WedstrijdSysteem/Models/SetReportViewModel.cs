using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedstrijdSysteem.Models
{
    public class SetReportViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Report { get; set; }
    }
}
