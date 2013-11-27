using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Category
    {
        [Key]
        public int category_ID { get; set; }
        [Display(Name = "Category Title")]
        public string category_title { get; set; }
        [Display(Name = "Category Description")]
        public string category_desc { get; set; }
        [Display(Name = "Time Period")]
        public string time_period { get; set; }
    }
}