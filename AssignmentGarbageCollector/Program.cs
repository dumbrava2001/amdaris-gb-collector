using AssignmentGarbageCollector.Services.Impl;

namespace AssignmentGarbageCollector;

internal static class Program
{
    public static void Main(string[] args)
    {
        var userService = new UserService(new GmailSender());

        Console.WriteLine("Hello there, please add your email to subscribe:");
        var userEmail = Console.ReadLine();

        if (userEmail != null)
        {
            userService.SubscribeUser(userEmail);
        }

        Console.WriteLine($"Congrats {userEmail}, now you are subscribed, see you soon... :)");
    }
}