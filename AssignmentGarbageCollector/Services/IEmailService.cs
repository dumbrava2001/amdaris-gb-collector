namespace AssignmentGarbageCollector.Services;

public interface IEmailService
{
    void SendEmail(string to, string subject, string message);
}