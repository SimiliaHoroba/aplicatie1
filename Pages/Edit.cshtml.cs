using aplicatie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aplicatie.Pages
{
    public class EditModel : PageModel
    {
        private readonly MyDbContext _context;

        [BindProperty]
        public Produs ProdusNou { get; set; }

        public EditModel(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            // Logica pentru preluarea datelor pentru editare
            ProdusNou = _context.Produse1.Find(id);

            if (ProdusNou == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Logica pentru salvarea modificărilor
            _context.Produse1.Update(ProdusNou);
            _context.SaveChanges();

            return RedirectToPage("/Produse1");
        }
    }
}
