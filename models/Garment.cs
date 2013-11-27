using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Garment
    {
        [Key]
        public int garment_ID { get; set; }
        [Display(Name = "Part of Costume")]
        public string costume_ID { get; set; }
        [Display(Name = "Main Category")]
        public string main_category_ID { get; set; }
        [Display(Name = "Sub Category")]
        public string sub_category_ID { get; set; }
        [Display(Name = "Material")]
        public string material_ID { get; set; }
        [Display(Name = "Pattern")]
        public string pattern_ID { get; set; }
        [Display(Name = "Storage")]
        public string storage_ID { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Type")]
        public string type { get; set; }
        [Display(Name = "Currently rented?")]
        public bool rented { get; set; }
        [Display(Name = "Rentable?")]
        public bool rentable { get; set; }
        public string photo { get; set; }
        [Display(Name = "Added to the Collection")]
        public string added_date { get; set; }
        [Display(Name = "Last Alteration")]
        public string last_altered { get; set; }
        [Display(Name = "Last Cleaning")]
        public string last_cleaned_date { get; set; }
        [Display(Name = "Cleaning Instructions")]
        public string cleaning_instr { get; set; }
    }
}