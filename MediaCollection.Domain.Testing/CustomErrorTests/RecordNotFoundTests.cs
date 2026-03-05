namespace MediaCollection.Domain.Testing.CustomErrorTests;

[ExcludeFromCodeCoverage]
public class RecordNotFoundTests
{
    [Fact]
    public void Should_CreateErrorWithProvidedMessageAndStatusCode()
    {
        // -- Arrange
        string message = "Record not found";
        int statusCode = 404;

        // -- Act
        CustomError customError = CustomError.RecordNotFound(message, statusCode);

        // -- Assert
        customError.Code.Should().Be(ErrorCodes.RecordNotFound);
        customError.Should().BeEquivalentTo(new CustomError(ErrorCodes.RecordNotFound,
            new CustomErrorInformation(404, "Record not found")));
    }
}
