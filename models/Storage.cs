using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Storage
    {
        [Key]
        public int storage_ID { get; set; }
        [Display(Name = "Location Description")]
        public string location_desc { get; set; }
        [Display(Name = "Environment")]
        public string environment { get; set; }
        [Display(Name = "Container")]
        public string container { get; set; }
        [Display(Name = "Item In House?")]
        public bool in_house { get; set; }
        [Display(Name = "Handling Instructions")]
        public string handling_instructions { get; set; }
    }
}