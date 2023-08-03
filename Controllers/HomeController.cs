using EmailTemplateApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailTemplateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ViewTemplate(int id)
        {
            var template = await _context.EmailTemplates.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }

            // Update the visit count
            template.VisitCount++;
            await _context.SaveChangesAsync();

            return View(template);
        }

    }
}
