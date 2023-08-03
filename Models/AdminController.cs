using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmailTemplateApp.Data;

namespace EmailTemplateApp.Models
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> EditTemplate(int id)
        {
            var template = await _context.EmailTemplates.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }

            return View(template);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTemplate(int id, [Bind("Id,Name,Content")] EmailTemplate template)
        {
            if (id != template.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(template);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(template);
        }

    }
}
