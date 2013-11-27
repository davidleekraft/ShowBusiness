using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string userPass { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Middle Name")]
        public string middleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Street Address")]
        public string streetAddress1 { get; set; }
        [Display(Name = "Street Address 2")]
        public string streetAddress2 { get; set; }
        [Display(Name = "Apt")]
        public int? apt { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "Zip Code")]
        public int? zip { get; set; }
        [Display(Name = "Zip Code Ext")]
        public int? zipExt { get; set; }


    }
}