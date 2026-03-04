namespace MediaCollection.Domain;

// TODO Write summaries
// TODO Unit test
public sealed record CustomError(string Code, string Message)
{
    private static readonly string _recordNotFoundCode = "RecordNotFound";
    private static readonly string _validationErrorCode = "ValidationError";

    public static readonly CustomError None = new(string.Empty, string.Empty);

    public static CustomError RecordNotFound(string message)
    {
        return new CustomError(_recordNotFoundCode, message);
    }

    public static CustomError ValidationError(string message)
    {
        return new CustomError(_validationErrorCode, message);
    }
}
