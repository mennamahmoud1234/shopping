using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping.Models
{
    public class Feedback
    { 
    public int Id { get; set; }
        public int Mobile { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Email { get; set; }

    }
}
