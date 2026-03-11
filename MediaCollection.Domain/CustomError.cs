using MediaCollection.Domain.Enums;
using MediaCollection.Domain.Models;

namespace MediaCollection.Domain;

public sealed record CustomError(ErrorCodes Code, CustomErrorInformation CustomErrorInformation)
{
    public static readonly CustomError None = new(ErrorCodes.Nothing,
        new CustomErrorInformation(string.Empty));

    public static CustomError RecordNotFound(string message)
    {
        return new CustomError(ErrorCodes.RecordNotFound,
            new CustomErrorInformation(message));
    }

    public static CustomError UnknownError(string message)
    {
        return new CustomError(ErrorCodes.UnknownError,
            new CustomErrorInformation(message));
    }
}
