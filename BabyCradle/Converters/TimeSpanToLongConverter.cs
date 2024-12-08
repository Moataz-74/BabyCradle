namespace BabyCradle.Converters;


public class TimeSpanToLongConverter : ValueConverter<TimeSpan, long>
{
    public TimeSpanToLongConverter()
        : base(
            v => v.Ticks,               // تحويل TimeSpan إلى Ticks (نوع long)
            v => TimeSpan.FromTicks(v)) // تحويل Ticks (نوع long) إلى TimeSpan
    {
    }
}

