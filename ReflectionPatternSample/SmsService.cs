namespace ReflectionPatternSample;

public class SmsService : IMessageService
{
    public void Send(string msg)
    {
        Console.WriteLine($"SMS: {msg}");
    }
}
