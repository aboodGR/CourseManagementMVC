using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        public IActionResult Details(int id) {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) {
                return NotFound();
            }
            return View(course);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course) {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course) {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
        [HttpPost]
        public IActionResult Delete(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
