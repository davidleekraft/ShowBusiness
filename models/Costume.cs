using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Costume
    {
        [Key]
        public int costume_ID { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Added Date")]
        public string creation_date { get; set; }
        [Display(Name = "Last Alteration")]
        public string last_altered { get; set; }
        [Display(Name = "Number of Components")]
        public int num_pieces { get; set; }
        public string photo { get; set; }
    }
}