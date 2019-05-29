using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzz;
using FizzBuzz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FizzBuzz.Pages
{
    public class Condition
    {
        Dictionary<int, string> conditions;
        StringBuilder sb; 

        public Condition()
        {
            conditions = new Dictionary<int, string>();
            sb = new StringBuilder("");
        }

        public void Add(int divisor, string value) => conditions.Add(divisor, value);

        public string StringAnswer(int number)
        {
            sb.Clear();
            foreach (var item in conditions)
                if (number % item.Key == 0) sb.Append(item.Value);

            if (sb.ToString() == "") sb.Append(number.ToString());
            return sb.ToString();
        }
    }
    public class IndexModel : PageModel
    {
        Condition condition;

        [BindProperty]
        public Log Logs { get; set; }
        public IndexModel()
        {
            condition = new Condition();
            condition.Add(3, "fizz");
            condition.Add(5, "buzz");
            condition.Add(7, "wizz");

            Logs = new Log();
        }

        [BindProperty]
        [Required]
        [Display(Name = "number")]
        public String Input { get; set; }
        [BindProperty]
        public String OutputString { get; set; }
        [BindProperty]
        public String ValidationMsg { get; set; }

        private string server = "(localdb)\\mssqllocaldb";

        public void OnGet()
        {
            Logs.Date = DateTime.Now;
            Logs.RemoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logs.LocalIpAddress = Request.HttpContext.Connection.LocalIpAddress.ToString();

            Input = "1";
            SaveLog(Logs);
        }

        public void OnPost()
        {
            if (Validation(Input))
            {
                OutputString = condition.StringAnswer(int.Parse(Input));
                ValidationMsg = "";
            }
            else
            {
                OutputString = "";
                ValidationMsg = "Podaj liczbe z przedzialu od 1 do 100!";
            }

        }

        private bool Validation(String s)
        {
            int.TryParse(s, out int number);

            if (number < 1 || number > 100) return false;
            return true;
        }

        public void SaveLog(Log log)
        {
            string connectionString = "Server="+server+";Database=FizzBuzzDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<FizzBuzzContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var con = new FizzBuzzContext(optionsBuilder.Options))
            {
                con.Logs.Add(log);
                con.SaveChanges();
            }
            
        }
    }
}
