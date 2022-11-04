using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping.Models
{
    public class Grocery
    {
        public int Id { get; set; }
      
        public string Description { get; set; }
        public int Price { get; set; }


        public byte[] Images { get; set; }
    }
}
