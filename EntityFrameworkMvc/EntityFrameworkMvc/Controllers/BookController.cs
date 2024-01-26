using EntityFrameworkMvc.Data;
using EntityFrameworkMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMvc.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _context.Books.Include(x => x.Author).ToListAsync();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result = await _context.Authors.ToListAsync();

            ViewBag.Authors = result;

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(Book book)
        {
            if(ModelState.IsValid)
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var result = await _context.Authors.ToListAsync();

            ViewBag.Authors = result;

            var currentBook = await _context.Books.FindAsync(id);

            if(currentBook != null) 
            {
                return View(currentBook);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task <ActionResult> Update(int BookId,Book book)
        {
            var isThereAnyBook = await _context.Books.FindAsync(BookId);

            if(isThereAnyBook != null)
            {
                isThereAnyBook.BookName = book.BookName;
                isThereAnyBook.BookDescription = book.BookDescription;
                isThereAnyBook.BookYearOfPublication = book.BookYearOfPublication;
                isThereAnyBook.AuthorId = book.AuthorId;

                _context.Update(isThereAnyBook);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if(book != null)
            {
                _context.Remove(book);
                await _context.SaveChangesAsync();

                return Json(new { message = "Book deleted successfully" });
            }
            else
            {
                return NotFound();
            }
        }

       

    }
}
