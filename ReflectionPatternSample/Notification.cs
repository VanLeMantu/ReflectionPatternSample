namespace ReflectionPatternSample;

public class Notification(IMessageService service)
{
    public void Notify(string msg)
    {
        service.Send(msg);
    }
}
