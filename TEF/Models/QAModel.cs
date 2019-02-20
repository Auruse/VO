using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcXML.Models
{
    public class QAModel
    {
        public int Id
        {
            get;
            set;
        }
        [Required]
        public string Dt
        {
            get;
            set;
        }
        [Required]
        public string Ct
        {
            get;
            set;
        }        
    }
}