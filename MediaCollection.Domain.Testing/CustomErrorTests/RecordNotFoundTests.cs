using MediaCollection.Domain.Enums;
using MediaCollection.Domain.Models;

namespace MediaCollection.Domain.Testing.CustomErrorTests;

[ExcludeFromCodeCoverage]
public class RecordNotFoundTests
{
    [Fact]
    public void Should_CreateErrorWithProvidedMessageAndStatusCode()
    {
        // -- Arrange
        string message = "Record not found";

        // -- Act
        CustomError customError = CustomError.RecordNotFound(message);

        // -- Assert
        customError.Code.Should().Be(ErrorCodes.RecordNotFound);
        customError.Should().BeEquivalentTo(new CustomError(ErrorCodes.RecordNotFound,
            new CustomErrorInformation("Record not found")));
    }
}
