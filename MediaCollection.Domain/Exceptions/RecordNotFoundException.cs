namespace MediaCollection.Domain.Exceptions;

// TODO Write summaries
public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(string message) : base(message)
    {
    }
}
