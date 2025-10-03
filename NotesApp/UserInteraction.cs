using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            while (true) {
            Console.WriteLine("Create Note. 1");
            Console.WriteLine("Delete Note. 2");
            Console.WriteLine("Show Notes. 3");
            Console.WriteLine("Close Programn. 4");
            string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        HandlingCreateNote();
                        break;
                    case "2":
                        HandlingDeleteNote();
                        break;
                    case "3":
                        HandlingShowNotes();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid input, Try again");
                        break;
                }
            }
        }
        public async void HandlingRegister()
        {
            Console.WriteLine("Type in Your name please");
            string name = Console.ReadLine();
            Console.WriteLine("Type in Your Email Please");
            string email = Console.ReadLine();
            Console.WriteLine("Type in Your Password please");
            string password = Console.ReadLine();

            await _userManagment.Register(name, email, password);
            Console.WriteLine("Youre Sucessfully registered");
            SignInUp();
        }
        public async void HandlingLogIn() {
            Console.WriteLine("Type in Your Name please.");
            string name = Console.ReadLine();
            Console.WriteLine("Type in Your Email please.");
            string email = Console.ReadLine();
            Console.WriteLine("Type in Your Password please.");
            string password = Console.ReadLine();

            Account account = await _userManagment.LogIn(name, email, password);

            if (account != null) {
                Console.WriteLine("Youre Sucessfully logged in");
                Menu();
            }
            else { 
                Console.WriteLine("Your Account Doesnt exist that way");
                SignInUp();
            }
            return;
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
                return;
            }
            Console.Clear();
            Console.WriteLine("--- Your Notes ---");
            // 
            for (int i = 0; i < _userManagment.currentUser.Notes.Count; i++)
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
            if (_userManagment.currentUser == null || _userManagment.currentUser.Notes.Count == 0) {
                Console.WriteLine("You dont have Notes");
            }
            Console.WriteLine("Which note would you like to delete ? Enter the number");
            string input = Console.ReadLine();
            int which;
            if (int.TryParse(input, out which))
            {
                if (which > 0 && which <= _userManagment.currentUser.Notes.Count)
                {
                    _userManagment.currentUser.Notes.RemoveAt(which - 1);
                    Console.WriteLine("Note deleted successfully!");
                }

            }
            else {
                Console.WriteLine("Invalid input. Please enter a valid number.");}
        }
            
    }
}
