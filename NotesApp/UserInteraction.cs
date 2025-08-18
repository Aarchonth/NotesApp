using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    internal class UserInteraction
    {
        private UserManagment _userManagment;
        // Konstruktor
        public UserInteraction(UserManagment userManagment)
        {
            _userManagment = userManagment;
        }
        public void SignInUp()
        { 
            Console.WriteLine("Register. 1");
            Console.WriteLine("Login. 2");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    HandlingRegister();
                    break;
                case "2":
                    HandlingLogIn();
                    break;
                default:
                    Console.WriteLine("Invalid input, Try again");
                    SignInUp(); // Restart
                    break;


            }
        }
        public void Menu()
        {
            Console.WriteLine("Create Note.");
            Console.WriteLine("Delete Note.");
            Console.WriteLine("Show Notes.");
            string input = Console.ReadLine();
            switch (input) {
                case "1":
                   HandlingCreateNote();
                    break;
                case "2":   // HandlingDeleteNote()
                    break;
                case "3":   // HandlingShowNotes()
                    break;
            default:
                    Console.WriteLine("Invalid input, Try again");
                    break;
            }
        }
        public void HandlingRegister()
        {
            Console.WriteLine("Type in Your name please");
            string name = Console.ReadLine();
            Console.WriteLine("Type in Your Email Please");
            string email = Console.ReadLine();
            Console.WriteLine("Type in Your Password please");
            string password = Console.ReadLine();

            _userManagment.Register(name, email, password);
        }
        public void HandlingLogIn() {
            Console.WriteLine("Type in Your Name please.");
            string name = Console.ReadLine();
            Console.WriteLine("Type in Your Email please.");
            string email = Console.ReadLine();
            Console.WriteLine("Type in Your Password please.");
            string password = Console.ReadLine();

            Account account = _userManagment.LogIn(name, email, password);

            if (account != null) {
                Console.WriteLine("Youre Sucessfully logged in");
                Menu();
            }
            else { 
                Console.WriteLine("Your Account Doesnt exist that way");
            }
        }
        public void HandlingCreateNote() {
            Console.WriteLine("What is the note title");
            string title = Console.ReadLine();
            Console.WriteLine($"Whats the Content of the Note [{title}]  ");
            string content = Console.ReadLine();
            _userManagment.CreateNote(title, content);
        }
       public void HandlingShowNotes()
        {
            if (_userManagment.currentUser == null || _userManagment.currentUser.Notes.Count == 0) {
                Console.WriteLine("You dont have Notes");
            }
                for (int i = 0; i > _userManagment.currentUser.Notes.Count; i++)
                {
                var note = _userManagment.currentUser.Notes[i];
                Console.WriteLine($"{i + 1} {note.Title}");
                Console.WriteLine($"    Inhalt: {note.Content}");
                Console.WriteLine("-----------------------------------");
            }
                
                
            }
        
        public void HandlingDeleteNote()
        {
         HandlingShowNotes();   
        }
            
    }
}
