namespace AssignmentGarbageCollector.Services.Impl;

public class UserService : IUserService
{
    private readonly IEmailService _emailService;

    public UserService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void SubscribeUser(string email)
    {
        const string emailSubject = "Internship subscribe";
        var emailMessage =
            $"Hello {email}, now you are subscribed to internship newsletter. We will keep in touch with you with all news.";

        _emailService.SendEmail(to: email, subject: emailSubject, message: emailMessage);
    }
}