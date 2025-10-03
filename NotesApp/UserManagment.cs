using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    internal class UserManagment
    {
        public List<Account> accounts = new List<Account>();
        public Account? currentUser { get; private set; }
        public UserManagment()
        {
            new DataPaths();
        }
        public async Task Register(string name, string email, string password)
        {
            Account account = new Account { 
            Name = name,
            Email = email,
            Password = password
            };
            string filePath = Path.Combine(DataPaths.UsersDir, name + ".json");
            await DataStorages.SaveToJsonFile(account, filePath);
            accounts.Add(account);
        }
        public async Task<Account?> LogIn(string name, string email, string password)
        {
            string filePath = Path.Combine(DataPaths.UsersDir, name + ".json");
            Account? loadedAccount = await DataStorages.LoadFromJsonFile<Account>(filePath);
            if (loadedAccount != null && loadedAccount.Password == password && loadedAccount.Email == email)
            {
                    currentUser = loadedAccount;
                    return currentUser;
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
