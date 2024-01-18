using aplicatie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace aplicatie.Pages
{
    public class DetaliiComanda1Model : PageModel
    {
        private readonly MyDbContext _context;
        public IEnumerable<DetaliiComanda> DetaliiComanda1 { get; set; } = new List<DetaliiComanda>();
        [BindProperty]
        public DetaliiComanda DetaliiComandaNoua { get; set; }

        public DetaliiComanda1Model(MyDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            DetaliiComanda1 = _context.DetaliiComanda1;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Verific? dac? exist? deja detalii comand? cu acela?i id
                if (!_context.DetaliiComanda1.Any(dc => dc.DetaliiComandaId == DetaliiComandaNoua.DetaliiComandaId))
                {
                    _context.DetaliiComanda1.Add(DetaliiComandaNoua);
                    _context.SaveChanges();

                    // Redirec?ionare c?tre o alt? pagin? dup? ad?ugarea cu succes a detaliilor comenzii
                    return RedirectToPage();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Detaliile comenzii cu acest ID exist? deja.");
                }
            }

            // În cazul în care modelul nu este valid sau exist? o problem? cu datele introduse, revenim pe aceea?i pagin?
            return Page();
        }
    }
}
