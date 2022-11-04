using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping.Models
{
    public class applicationuser: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

      

    }
}
