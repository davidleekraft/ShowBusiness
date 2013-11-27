using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Production
    {
        [Key]
        public int production_ID { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Start Date")]
        public string start_date { get; set; }
        [Display(Name = "End Date")]
        public string end_date { get; set; }
    }
}