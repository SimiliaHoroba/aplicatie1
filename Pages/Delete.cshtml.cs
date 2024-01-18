// Delete.cshtml.cs

using aplicatie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace aplicatie.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MyDbContext _context;

        [BindProperty]
        public Produs ProdusDeSters { get; set; }

        public DeleteModel(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            ProdusDeSters = _context.Produse1.Find(id);

            if (ProdusDeSters == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            ProdusDeSters = _context.Produse1.Find(ProdusDeSters.ProdusId);

            if (ProdusDeSters != null)
            {
                _context.Produse1.Remove(ProdusDeSters);
                _context.SaveChanges();

                return RedirectToPage("/Produse1");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
