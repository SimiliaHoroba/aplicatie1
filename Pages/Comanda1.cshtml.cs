using aplicatie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace aplicatie.Pages
{
    public class Comanda1Model : PageModel
    {
        private readonly MyDbContext _context;
        public IEnumerable<Comanda> Comenzi1 { get; set; } = new List<Comanda>();
        [BindProperty]
        public Comanda ComandaNoua { get; set; }

        public Comanda1Model(MyDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Comenzi1 = _context.Comanda1;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Comanda1.Add(ComandaNoua);
                _context.SaveChanges();

                // Redirecționare către o altă pagină după adăugarea cu succes a comenzii
                return RedirectToPage();
            }

            // În cazul în care modelul nu este valid, revenim pe aceeași pagină
            return Page();
        }
    }
}
