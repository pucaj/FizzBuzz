using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FizzBuzz;

namespace FizzBuzz.Models
{
    public class FizzBuzzContext : DbContext
    {
        public FizzBuzzContext (DbContextOptions<FizzBuzzContext> options)
            : base(options)
        {
        }

        public DbSet<FizzBuzz.Log> Logs { get; set; }
    }
}
