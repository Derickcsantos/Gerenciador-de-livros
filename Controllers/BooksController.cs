using LibraryManager.Web.Data;
using LibraryManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManager.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}