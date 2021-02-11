using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorView_ASPNET.Models
{
    // Math Model Class
    public class MathModel
    {
        // Input Model
        [Required(ErrorMessage ="Number is Requried")]
        // Property 
        public decimal FirstNumber { get; set; }

        // Custom Error
        [Required(ErrorMessage ="Number is Requried")] // Data Annotation
        // Property 
        public decimal SecondNumber { get; set; }
        // Result Property
        // Property 
        public decimal Result { get; set; }
    }
}
