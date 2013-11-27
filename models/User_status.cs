using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class User_status
    {
        [Key]
        public int statusID { get; set; }
        public string title { get; set; }
        public string privileges { get; set; }
    }
}