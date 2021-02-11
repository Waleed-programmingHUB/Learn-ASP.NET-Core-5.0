using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using RazorView_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RazorView_ASPNET.Controllers
{
    public class HomeController : Controller
    {
        // Call Ihost Environment
        private readonly IWebHostEnvironment _webEnv;
        // Constructor
        public HomeController(IWebHostEnvironment webHost)
        {
            this._webEnv = webHost;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        // Main Page View Database
        public ActionResult Index()
        {
            ViewBag.title = "Home";
            // Show the List Student from Database
            StudentViewModel studentView = new StudentViewModel();
            List<StudentModel> model = studentView.ShowStudents();

            return View(model);
        }
    
        // Math Model Page
        [HttpGet]
        public ActionResult SimpleMath()
        {
            ViewBag.title = "Simple Math";
            MathModel m = new MathModel();
            m.Result = 0;
            return View(m);
        }
        
        [HttpPost] // POST Request
        public ActionResult SimpleMath(MathModel model)
        {
            ViewBag.title = "Simple Math";
            if (ModelState.IsValid)
            {
                decimal v1 = model.FirstNumber; // Input Text
                decimal v2 = model.SecondNumber; // Input Text
                model.Result = v1 + v2; // Output
            }
            return View(model); // Returing here
        }

        // Report Generate Code
        // Report Index Action
        public IActionResult ReportGenerate()
        {
            string m_type = "";
            int extension = 1; 
            // Path of Report Template
            var path = $"Models\\Report\\Report.rdlc";
            // Dictionary 
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            // Add Parameter of Report @parameter RDLC Report
            parameters.Add("ReportParameter1", "Bismillah Testing a Report Waleed");
            // Local Report 
            LocalReport report = new LocalReport(path /* passing a parameter of report directory */);
            // Result
            var result = report.Execute(RenderType.Pdf, extension, parameters, m_type);

            // Returning a value
            return File(result.MainStream, "application/pdf"); // Print to PDF Form
        }


    }
}
