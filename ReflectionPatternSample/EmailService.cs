namespace ReflectionPatternSample;

public class EmailService : IMessageService
{
    public void Send(string msg)
    {
        Console.WriteLine($"Email: {msg}");
    }
}
