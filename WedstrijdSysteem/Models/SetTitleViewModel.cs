using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedstrijdSysteem.Models
{
    public class SetTitleViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }
    }
}
