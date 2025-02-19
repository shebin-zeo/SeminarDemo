using Microsoft.AspNetCore.Mvc;
using SeminarDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeminarDemo.Controllers
{
    public class StudentController : Controller
    {
        // A static list to simulate a database
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new Student { Id = 2, Name = "Jane Doe", Email = "jane@example.com" }
        };

        // GET: /Student/
        public IActionResult Index()
        {
            return View(students);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Simulate auto-increment of Id
                student.Id = (students.Count > 0) ? students.Max(s => s.Id) + 1 : 1;
                students.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: /Student/Edit/5
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: /Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var studentToUpdate = students.FirstOrDefault(s => s.Id == id);
                if (studentToUpdate != null)
                {
                    studentToUpdate.Name = student.Name;
                    studentToUpdate.Email = student.Email;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: /Student/Delete/5
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
