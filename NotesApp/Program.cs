using NotesApp;

class Program
{
    static void Main()
    {
        UserManagment userManagment = new UserManagment();
        UserInteraction.HandlingRegister(userManagment);
        UserInteraction.HandlingLogIn(userManagment);
    }
}