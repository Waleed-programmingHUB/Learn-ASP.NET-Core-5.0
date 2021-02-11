using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorView_ASPNET.Controllers
{
    public class RazorPController : Controller
    {
        // Razor Page Controller
        public ActionResult Index()
        {
            ViewBag.title = "RazorView"; // Set the Title and store to ViewBag
            return View();
        }

    }
}
