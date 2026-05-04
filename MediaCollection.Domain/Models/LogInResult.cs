namespace MediaCollection.Domain.Models;

/// <summary>
/// The dto that is returned to the caller after succesfully logging in.
/// </summary>
[ExcludeFromCodeCoverage]
public record LogInResult()
{
    /// <summary>
    /// The username.
    /// </summary>
    public string UserName { get; init; } = string.Empty;

    /// <summary>
    /// The user's role.
    /// </summary>
    public string Role { get; init; } = string.Empty;

    /// <summary>
    /// The jwt bearer token.
    /// </summary>
    public string AccessToken { get; init; } = string.Empty;

    /// <summary>
    /// The refreshtoken.
    /// </summary>
    public string RefreshToken { get; init; } = string.Empty;
}
