using MediaCollection.Domain.Enums;
using MediaCollection.Domain.Models;

namespace MediaCollection.Domain;

[ExcludeFromCodeCoverage]
public sealed record CustomError(ErrorCodes Code, CustomErrorInformation CustomErrorInformation)
{
    public static readonly CustomError None = new(ErrorCodes.Nothing, new CustomErrorInformation(string.Empty));

    public static CustomError RecordNotFound(string message)
    {
        return new CustomError(ErrorCodes.RecordNotFound, new CustomErrorInformation(message));
    }

    public static CustomError UnknownError(string message)
    {
        return new CustomError(ErrorCodes.UnknownError, new CustomErrorInformation(message));
    }

    public static CustomError UserNotConfirmed(string message)
    {
        return new CustomError(ErrorCodes.UserNotConfirmed, new CustomErrorInformation(message));
    }

    public static CustomError Unauthorized(string message)
    {
        return new CustomError(ErrorCodes.Unauthorized, new CustomErrorInformation(message));
    }
}
