using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class Material
    {
        [Key]
        public int material_ID { get; set; }
        public string description { get; set; }
    }
}