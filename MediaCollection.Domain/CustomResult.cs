namespace MediaCollection.Domain;

public class CustomResult<T> where T : class
{
    private readonly T? _value;

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public CustomError Error { get; }
    public T Value
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException("There is no value for failure");
            }

            return _value!;
        }

        private init => _value = value;
    }

    private CustomResult(T value)
    {
        _value = value;
        IsSuccess = true;
        Error = CustomError.None;
    }

    private CustomResult(CustomError error)
    {
        if (error == CustomError.None)
        {
            throw new ArgumentException("Invalid error.", nameof(error));
        }

        IsSuccess = false;
        Error = error;
    }

    public static CustomResult<T> Success(T value)
    {
        return new CustomResult<T>(value);
    }

    public static CustomResult<T> Failure(CustomError error)
    {
        return new CustomResult<T>(error);
    }
}
