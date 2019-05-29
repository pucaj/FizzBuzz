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
    public class IndexModel : PageModel
    {
        private readonly FizzBuzz.Models.FizzBuzzContext _context;

        public IndexModel(FizzBuzz.Models.FizzBuzzContext context)
        {
            _context = context;
        }

        public IList<Log> Logs { get;set; }

        public async Task OnGetAsync()
        {
            Logs = await _context.Logs.ToListAsync();
        }
    }
}
