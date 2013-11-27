using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Rental
    {
        [Key]
        public int rental_ID { get; set; }
        [Display(Name = "Renter")]
        public string renter_ID { get; set; }
        [Display(Name = "Prop")]
        public string prop_ID { get; set; }
        [Display(Name = "Garment")]
        public string garment_ID { get; set; }
        [Display(Name = "Date Rented")]
        [Required]
        public string date_taken { get; set; }
        [Display(Name = "Date Returned")]
        public string date_returned { get; set; }
        [Display(Name = "Condition Returned")]
        public string cond_returned { get; set; }
        [Display(Name = "Rental Cost")]
        [Required]
        public string cost { get; set; }
        [Display(Name = "Rented In / Out")]
        [Required]
        public bool in_out { get; set; }
    }

}