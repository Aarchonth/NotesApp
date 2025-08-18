using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    internal class UserManagment
    {
        public List<Account> accounts = new List<Account>();
        public Account? currentUser { get; private set; }
        public void Register(string name, string email, string password)
        {
            Account account = new Account { 
            Name = name,
            Email = email,
            Password = password
            };
            accounts.Add(account);
        }
        public Account? LogIn(string name, string email, string password)
        {
            foreach (var account in accounts) 
            {
                if (account.Name == name && account.Email == email && account.Password == password) 
                {
                    currentUser = account;
                    return account;
                }
            }
            return null;
        }
        public bool CreateNote(string title, string content) {
        if(currentUser == null) { return false; }
        Note note = new Note { 
            Title = title,
            Content = content,
            CreatedAt = DateTime.Now
        };
            currentUser.Notes.Add(note);
            return true;
        }
        
    }
}
