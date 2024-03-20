namespace AssignmentGarbageCollector.Exceptions;

public class EmailSenderException : Exception
{
    public EmailSenderException(string? message) : base(message)
    {
    }

    public EmailSenderException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}