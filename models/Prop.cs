using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Prop
    {
        [Key]
        public int prop_ID { get; set; }
        [Display(Name = "Main Category")]
        public string main_category_ID { get; set; }
        [Display(Name = "Sub Category")]
        public string sub_category_ID { get; set; }
        [Display(Name = "Material")]
        public string material_ID { get; set; }
        [Display(Name = "Storage")]
        public string storage_ID { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Currently rented?")]
        public bool rented { get; set; }
        [Display(Name = "Rentable?")]
        public bool rentable { get; set; }
        [Display(Name = "Last Cleaning")]
        public string last_cleaned_date { get; set; }
        [Display(Name = "Cleaning Instructions")]
        public string cleaning_instr { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Photo")]
        public string photo { get; set; }
    }
}