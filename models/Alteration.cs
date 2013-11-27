using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Alteration
    {
        [Key]
        public int alteration_ID { get; set; }
        [Display(Name = "Garment")]
        public string garment_ID { get; set; }
        [Display(Name = "Prop")]
        public string prop_ID { get; set; }
        [Display(Name = "Alteration Date")]
        [Required]
        public string date_altered { get; set; }
        [Display(Name = "Is Alteration Permanent?")]
        [Required]
        public bool permanent { get; set; }
        [Display(Name = "Previous State")]
        [Required]
        public string previous_state { get; set; }
        [Display(Name = "New State")]
        [Required]
        public string new_state { get; set; }
    }
}