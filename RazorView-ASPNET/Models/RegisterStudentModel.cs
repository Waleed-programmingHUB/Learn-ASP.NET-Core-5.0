using System;
using System.ComponentModel.DataAnnotations;

namespace RazorView_ASPNET.Models
{
    public class RegisterStudentModel
    {
        // Form Data Validation Model Property
        [Display (Name ="User Name")] // Data Annotation
        [Required (ErrorMessage ="User Name is Requried") , MaxLength(12)] // Data Annotation
        [MinLength(3, ErrorMessage = "Your Name should have atleast 3 Character")]
        // Property Input Types
        public string UserName { get; set; }

        [Display(Name = "Password")] // Data Annotation
        [Required(ErrorMessage = "Password is Requried"),MaxLength(12)] // Data Annotation
        [DataType(DataType.Password)] // Data Annotation
        [MinLength(3,ErrorMessage = "Password should be atleast 3 Character")]
        // Property Input Types
        public string Password{ get; set; }

        [Display(Name = "Confirm Password")] // Data Annotation
        [Required(ErrorMessage = "Confirm Password is Requried"), MaxLength(12)] // Data Annotation
        [DataType(DataType.Password)] // Data Annotation
        [MinLength(3, ErrorMessage = "Password should be atleast 3 Character")] // Data Annotation
        [Compare("Password",ErrorMessage = "Password is not same")]
        // Property Input Types
        public string ConfirmPassword{ get; set; }

        [Display(Name = "You can't proceed further until you accept our Terms & Conditions.")] // Data Annotation
        // Property Input Types
        public bool IsAgreedToTerms{ get; set; }
    }
}
