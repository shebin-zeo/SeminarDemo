using Microsoft.AspNetCore.Mvc;
using SeminarDemo.Models;
using System.Collections.Generic;

namespace SeminarDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: /Student/Index
        public IActionResult Index()
        {
            // Create a sample list of students
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Sumith", Email = "Sumith@example.com" },
                new Student { Id = 2, Name = "Janaki", Email = "Janaki@example.com" },
                 new Student { Id = 3, Name = "Safar", Email = "Safar@example.com" }
            };

            // Ensure we're passing a non-null list
            return View(students);
        }
    }
}
