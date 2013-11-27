using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Damage
    {
        [Key]
        public int damage_ID { get; set; }
        [Display(Name = "Garment")]
        public string garment_ID { get; set; }
        [Display(Name = "Prop")]
        public string prop_ID { get; set; }
        [Display(Name = "Date Damaged")]
        [Required]
        public DateTime date_damaged { get; set; }
        [Display(Name = "Expected Repair Date")]
        [Required]
        public DateTime exp_repair_date { get; set; }
        [Display(Name = "Repaired Date")]
        public DateTime? repaired_date { get; set; }
        [Display(Name = "Description of Repair")]
        public string repair_desc { get; set; }
    }
}