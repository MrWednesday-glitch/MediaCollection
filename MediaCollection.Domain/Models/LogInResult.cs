namespace MediaCollection.Domain.Models;

// TODO Summaries
[ExcludeFromCodeCoverage]
public record LogInResult()
{
    public string UserName { get; init; } = string.Empty;

    public string Role { get; init; } = string.Empty;

    public string AccessToken { get; init; } = string.Empty;

    public string RefreshToken { get; init; } = string.Empty;
}
