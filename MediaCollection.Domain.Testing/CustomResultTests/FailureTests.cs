namespace MediaCollection.Domain.Testing.CustomResultTests;

[ExcludeFromCodeCoverage]
public class FailureTests
{
    [Fact]
    public void Should_CreateFailureResultWithError()
    {
        // -- Arrange
        CustomError error = CustomError.UnknownError("Banana overrijp.");

        // -- Act
        CustomResult<Banana> bananaResult = CustomResult<Banana>.Failure(error);

        // -- Assert
        bananaResult.IsSuccess.Should().BeFalse();
        bananaResult.IsFailure.Should().BeTrue();
        bananaResult.Error.Should().BeEquivalentTo(error);
    }
}

[ExcludeFromCodeCoverage]
internal class Banana
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
