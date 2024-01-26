using EntityFrameworkMvc.Data;
using EntityFrameworkMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMvc.Controllers
{
    public class AuthorProfileController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AuthorProfileController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _appDbContext.AuthorProfiles.Include(x=>x.Author).ToListAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
           if(id == 0)
            {
                return NotFound("There is no id for author");
            }
            else
            {
                AuthorProfile authorProfile = new AuthorProfile();  
                authorProfile.AuthorId = id;
                return View(authorProfile);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorProfile authorProfile)
        {
            if (ModelState.IsValid)
            {
                await _appDbContext.AuthorProfiles.AddAsync(authorProfile);
                await _appDbContext.SaveChangesAsync();

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
            var result = await _appDbContext.AuthorProfiles.FindAsync(id);

            if(result != null)
            {
                return View(result);
            }
            else
            {
                return RedirectToAction("Index");   
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update(int AuthorProfileId,AuthorProfile authorProfile)
        {
            var result = await _appDbContext.AuthorProfiles.FindAsync(AuthorProfileId);
            
            if(result != null)
            {
                result.SocialMedia = authorProfile.SocialMedia;
                result.WebSite = authorProfile.WebSite;
               
                _appDbContext.Update(result);
                await _appDbContext.SaveChangesAsync();

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
            var result = await _appDbContext.AuthorProfiles.FindAsync(id);

            if (result != null)
            {
                _appDbContext.Remove(result);
                await _appDbContext.SaveChangesAsync();

                return Json(new { message = "AuthorProfile deleted successfully" });
            }
            else
            {
                return NotFound();
            }
        }

    }
}
