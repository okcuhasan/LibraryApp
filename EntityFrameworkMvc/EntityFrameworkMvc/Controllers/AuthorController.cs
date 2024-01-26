using EntityFrameworkMvc.Data;
using EntityFrameworkMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMvc.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authors =  await _context.Authors.ToListAsync();

            return View(authors);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            if(ModelState.IsValid)
            {
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var authors = await _context.Authors.FindAsync(id);

            if(authors != null)
            {
                return View(authors);
            }
            else
            {
                return RedirectToAction("Index");   
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update(int AuthorId,Author author)
        {
            var isThereAnyAuthor = _context.Authors.Find(AuthorId);

            if(isThereAnyAuthor != null)
            {
                isThereAnyAuthor.AuthorName = author.AuthorName;
                isThereAnyAuthor.AuthorBirthDate = author.AuthorBirthDate;
                isThereAnyAuthor.AuthorsBirthPlace = author.AuthorsBirthPlace;
                isThereAnyAuthor.AuthorsSchool = author.AuthorsSchool;

                _context.Authors.Update(isThereAnyAuthor);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteAuthor = await _context.Authors.FindAsync(id);

            if(deleteAuthor != null)
            {
                 _context.Authors.Remove(deleteAuthor);
                 await _context.SaveChangesAsync();

                return Json(new {message = "Author deleted sucessfully"});
            }
            else
            {
                return RedirectToAction("Index");
            }
        }



    }
}
