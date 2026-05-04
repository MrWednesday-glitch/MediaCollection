namespace MediaCollection.Business;

/// <summary>
/// A class to wrap around any calls to datetime.now.
/// Userful for testing purposes.
/// </summary>
public class DateTimeWrapper
{
    private readonly DateTime? _dateTime;

    /// <summary>
    /// Initializes the constructor.
    /// </summary>
    /// <param name="fixedDateTime">A nullable parameter, useful for unit testing purposes.</param>
    public DateTimeWrapper(DateTime? fixedDateTime = null)
    {
        _dateTime = fixedDateTime;
    }

    /// <summary>
    /// Calls the datetime.now.
    /// </summary>
    public DateTime Now
    {
        get
        {
            return _dateTime ?? DateTime.Now;
        }
    }

    /// <summary>
    /// Calls the datetime.utcnow.
    /// </summary>
    public DateTime UtcNow
    {
        get
        {
            return _dateTime ?? DateTime.UtcNow;
        }
    }
}
