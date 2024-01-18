using aplicatie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace aplicatie.Pages
{
    public class Produse1Model : PageModel
    {
        private readonly MyDbContext _context;
        public IEnumerable<Produs> Produse1 { get; set; } = new List<Produs>();
        [BindProperty]
        public Produs ProdusNou { get; set; }

        public Produse1Model(MyDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Produse1 = _context.Produse1;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Produse1.Add(ProdusNou);
                _context.SaveChanges();

                // Redirec?ionare c?tre o alt? pagin? dup? ad?ugarea cu succes a utilizatorului
                return RedirectToPage();
            }

            // În cazul în care modelul nu este valid, revenim pe aceea?i pagin?
            return Page();
        }
    }
}
