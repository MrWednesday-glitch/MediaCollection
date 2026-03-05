namespace MediaCollection.Domain;

// TODO Write summaries
public sealed record CustomError(ErrorCodes Code, CustomErrorInformation CustomErrorInformation)
{
    public static readonly CustomError None = new(ErrorCodes.Nothing,
        new CustomErrorInformation(500, string.Empty));

    public static CustomError RecordNotFound(string message, int statusCode)
    {
        return new CustomError(ErrorCodes.RecordNotFound,
            new CustomErrorInformation(statusCode, message));
    }
    
    public static CustomError UnknownError(string message, int statusCode)
    {
        return new CustomError(ErrorCodes.UnknownError, 
            new CustomErrorInformation(statusCode, message));
    }
}

// TODO Edit the readme about the result pattern and why I want it
