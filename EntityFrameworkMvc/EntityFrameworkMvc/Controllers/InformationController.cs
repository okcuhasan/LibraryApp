using EntityFrameworkMvc.Data;
using EntityFrameworkMvc.Models;
using EntityFrameworkMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMvc.Controllers
{
    public class InformationController : Controller
    {
        private readonly AppDbContext _dbContext;

        public InformationController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string authorName)
        {
            var vm = new InformationVM();

            var authors = await _dbContext.Authors.Include(x => x.Books)
                .Include(x => x.AuthorProfile)
                .Include(x => x.AuthorPublishers)
                .Where(x => x.AuthorName == authorName)
                .ToListAsync();
            
            

            if (authors.Count == 0)
            {
                return NotFound("error");
            }
            else
            {
                vm.AuthorData = authors;
                vm.BookData = authors.SelectMany(x=>x.Books).ToList();
                vm.AuthorProfileData = authors.Select(x=>x.AuthorProfile).ToList();
                vm.AuthorPublisherData = authors.SelectMany(x=>x.AuthorPublishers).ToList();
                /*
                 ı use select to access a single data in the list, select many to access multiple data
                */
            }

            return View(vm);
        }

    }
}
