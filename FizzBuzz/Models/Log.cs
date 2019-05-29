using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class Log
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public String RemoteIpAddress { get; set; }
        public String LocalIpAddress { get; set; }
    }
}
