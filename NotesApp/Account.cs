using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{

    internal class Account
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    internal enum Role
    {
        Admin,
        User
    }
}
