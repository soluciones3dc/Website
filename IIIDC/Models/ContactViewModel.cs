using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IIIDC.Models
{
    public class ContactViewModel
    {
        [StringLength(maximumLength: = 20, ErrorMessage ="The name is too short")]
        [Required]
        public string Name { get; set; }

        public string Subject { get; set; }

        [StringLength(50)]
        [Required]
        [EmailAddress]
        public string  Email { get; set; }

        [Phone]
        public string Telephone { get; set; }

        [StringLength(400)]
        public string Content { get; set; }


    }
}
