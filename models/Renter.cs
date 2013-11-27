using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Renter
    {
        [Key]
        public int renter_ID { get; set; }
        [Display(Name = "Company Name")]
        public string company_name { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string first_name { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string last_name { get; set; }
        [Display(Name = "Street Address")]
        [Required]
        public string street_address { get; set; }
        [Display(Name = "City")]
        [Required]
        public string city { get; set; }
        [Display(Name = "State")]
        [Required]
        public string state { get; set; }
        [Display(Name = "Zip Code")]
        [Required]
        public string zip { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string phone{ get; set; }
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Display(Name = "Date Joined")]
        [Required]
        public DateTime renter_since { get; set; }
        [Display(Name = "Renter Status")]
        public string status { get; set; }
    }

}