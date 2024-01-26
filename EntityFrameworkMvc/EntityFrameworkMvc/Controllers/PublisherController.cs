using EntityFrameworkMvc.Data;
using EntityFrameworkMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMvc.Controllers
{
    public class PublisherController : Controller
    {
        private readonly AppDbContext _context;

        public PublisherController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var publishers = await _context.Publishers.ToListAsync();

            return View(publishers);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Publisher p)
        {
            if (ModelState.IsValid)
            {
                _context.Publishers.Add(p);
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
            var publishers = await _context.Publishers.FindAsync(id);

            if (publishers != null)
            {
                return View(publishers);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update(int PublisherId, Publisher x)
        {
            var isThereAnyPublisher = _context.Publishers.Find(PublisherId);

            if (isThereAnyPublisher != null)
            {
                isThereAnyPublisher.PublisherName = x.PublisherName;
           

                _context.Publishers.Update(isThereAnyPublisher);
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
            var deletePublisher = await _context.Publishers.FindAsync(id);

            if (deletePublisher != null)
            {
                _context.Publishers.Remove(deletePublisher);
                await _context.SaveChangesAsync();

                return Json(new { message = "Publisher deleted sucessfully" });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}

