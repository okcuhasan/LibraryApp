using EntityFrameworkMvc.Data;
using EntityFrameworkMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMvc.Controllers
{
    public class AuthorPublisherController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorPublisherController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var inc = await _context.AuthorPublishers.Include(x => x.Author)
                .Include(x => x.Publisher).ToListAsync();

            return View(inc);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result = await _context.Publishers.ToListAsync();

            ViewBag.Publishers = result;

            var result2 = await _context.Authors.ToListAsync();
            ViewBag.Authors = result2;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorPublisher authorp)
        {
            if (ModelState.IsValid)
            {
                _context.AuthorPublishers.Add(authorp);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
