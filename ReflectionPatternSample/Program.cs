using ReflectionPatternSample;

var obj = Create<Notification>();
obj.Notify("Hello reflection!");

static T Create<T>()
{
    var type = typeof(T);
    var ctor = type.GetConstructors().First();

    var parameters = ctor.GetParameters()
        .Select(p => Activator.CreateInstance(typeof(SmsService)))
        .ToArray();

    return (T)ctor.Invoke(parameters);
}