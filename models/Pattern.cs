using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Pattern
    {
        [Key]
        public int pattern_ID { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
    }
}