using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Size
    {
        [Key]
        public int size_ID { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string type { get; set; }
        [Display(Name = "Size")]
        public int value { get; set; }
        [Display(Name = "Garment")]
        public string garment_ID { get; set; }
        [Display(Name = "Performer")]
        public string performer_ID { get; set; }
        [Display(Name = "Prop")]
        public string prop_ID { get; set; }
    }
}