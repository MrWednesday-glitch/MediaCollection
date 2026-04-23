namespace MediaCollection.Business;

// TODO UnitTest
// TODO Summaries
// TODO Explain this in the readme
public class DateTimeWrapper
{
    private readonly DateTime? _dateTime;

    public DateTimeWrapper(DateTime? fixedDateTime = null)
    {
        _dateTime = fixedDateTime;
    }

    public DateTime Now
    {
        get
        {
            return _dateTime ?? DateTime.Now;
        }
    }

    public DateTime UtcNow
    {
        get
        {
            return _dateTime ?? DateTime.UtcNow;
        }
    }
}
