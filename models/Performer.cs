using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Performer
    {
        [Key]
        public int performer_ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string first_name { get; set; }
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
        [Display(Name = "Phone Number")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Street Address")]
        public string street_address { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "Zip Code")]
        public string zip { get; set; }
        [Display(Name = "Age")]
        public int age { get; set; }
        [Display(Name = "Photo")]
        public string photo { get; set; }
    }
}