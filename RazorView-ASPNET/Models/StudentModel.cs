using System;
using System.ComponentModel.DataAnnotations;

namespace RazorView_ASPNET.Models
{
    // Class 
    public class StudentModel
    {
        // Using a DataAnontations
        [Display(Name = "Roll Nunber")] // Name of anontations
        //[Required(ErrorMessage ="Roll Number is requried")] // show error validation
        public int roll_number  { get; set; } // property


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is requried")]
        public string name { get; set; }


        [Display(Name = "Subjects")]
        [Required(ErrorMessage = "Elective Subjects is requried")]
        public string subjects { get; set; }


        [Display(Name = "Class Name")]
        [Required(ErrorMessage = "Class is requried")]
        public string class_name { get; set; }


        [Display(Name = "DateOfBirth")]
        [Required(ErrorMessage = "Date Of Birth is requried")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

    }
}
