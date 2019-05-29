using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzz;
using FizzBuzz.Models;

namespace FizzBuzz.Pages.Logs
{
    public class DetailsModel : PageModel
    {
        private readonly FizzBuzz.Models.FizzBuzzContext _context;

        public DetailsModel(FizzBuzz.Models.FizzBuzzContext context)
        {
            _context = context;
        }

        public Log Logs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Logs = await _context.Logs.FirstOrDefaultAsync(m => m.Id == id);

            if (Logs == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
