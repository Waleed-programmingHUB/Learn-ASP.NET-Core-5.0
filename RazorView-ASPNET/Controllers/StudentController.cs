using Microsoft.AspNetCore.Mvc;
using RazorView_ASPNET.Models;


namespace RazorView_ASPNET.Controllers
{
    // Using a Ms SQL Server 
    // Student Apply Form 
    // Insert ,Update , Delete ,Read Functions
    public class StudentController : Controller
    {
        // Apply Student
        public ActionResult Index(int roll_number= 0)
        {
            ViewBag.title = "Apply Form";
            // This Object
            StudentModel student = new StudentModel();
            student.roll_number = 0;

            // if user is new redirect to Apply Page
            if (roll_number == 0)
            {
                // Insert
                student.roll_number = 0;
            }
            else 
            {
                // Update data
                StudentViewModel update_student = new StudentViewModel();
                student = update_student._EditStudent(roll_number); 
            }
            return View(student);
        } 
        // POST REQUEST
        [HttpPost]
        public ActionResult Index(StudentModel student)
        {
            ViewBag.title = "Apply Form";
            if (ModelState.IsValid)
            {
                ViewBag.title = "New Student";
                StudentViewModel s = new StudentViewModel();
                if (student.roll_number == 0)
                {
                    // Insert to New Student
                    s._RegisterStudent(student);
                }
                else
                {
                    ViewBag.title = "Update Student";
                    s.UpdateStudent(student);
                }
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        // Delete Action Result
        public ActionResult DeleteStudent(int roll_number = 0)
        {
            // Delete the By Roll Number
            StudentViewModel delete_student = new StudentViewModel();
            delete_student._DeleteStudent(roll_number);
            return  RedirectToAction("Index","Home"); // Redirect to Main Page
        }

        // Register User
        // New User Page View 
        public ActionResult RegisterStudent()
        {
            ViewBag.title = "Registration";
            return View();
        }
         // Register User POST
         [HttpPost]
        public ActionResult RegisterStudent(RegisterStudentModel rsm)
        {
            ViewBag.title = "Registration";
            if (!rsm.IsAgreedToTerms)
            {
                // If user does not apply to proceed this will error to label
                ModelState.AddModelError("IsAgreedToTerms","Please Check to proceed further..."); 
            }
            return View(); // return Page
        }

       
    }
}
