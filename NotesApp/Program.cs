using NotesApp;

class Program
{
    static void Main()
    {
        UserManagment userManagment = new UserManagment();
        UserInteraction userInteraction = new UserInteraction(userManagment);
        userInteraction.SignInUp();
    }
}