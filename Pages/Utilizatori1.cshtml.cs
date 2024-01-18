using aplicatie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace aplicatie.Pages
{
    public class Utilizatori1Model : PageModel
    {
        private readonly MyDbContext _context;
        public IEnumerable<Utilizator> Utilizatori1 { get; set; } = new List<Utilizator>();
        [BindProperty]
        public Utilizator UtilizatorNou { get; set; }

        public Utilizatori1Model(MyDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Utilizatori1 = _context.Utilizatori1;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Utilizatori1.Add(UtilizatorNou);
                _context.SaveChanges();

                // Redirec?ionare c?tre o alt? pagin? dup? ad?ugarea cu succes a utilizatorului
                return RedirectToPage();
            }

            // În cazul în care modelul nu este valid, revenim pe aceea?i pagin?
            return Page();
        }
    }
}
