using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    internal class UserInteraction
    {
        public static void HandlingRegister(UserManagment userManagment)
        {
            Console.WriteLine("Type in Your name please");
            string name = Console.ReadLine();
            Console.WriteLine("Type in Your Email Please");
            string email = Console.ReadLine();
            Console.WriteLine("Type in Your Password please");
            string password = Console.ReadLine();

            userManagment.Register(name, email, password);
        }
        public static void HandlingLogIn(UserManagment userManagment) {
            Console.WriteLine("Type in Your name please");
            string name = Console.ReadLine();
            Console.WriteLine("Type in Your Email Please");
            string email = Console.ReadLine();
            Console.WriteLine("Type in Your Password please");
            string password = Console.ReadLine();

            Account account = userManagment.LogIn(name, email, password);

            if (account != null) {
                Console.WriteLine("Youre Sucessfully logged in");
            }
            else { 
                Console.WriteLine("Your Account Doesnt exist that way");
            }
        }
    }
}
