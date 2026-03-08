namespace MediaCollection.Domain.Testing.CustomErrorTests;

[ExcludeFromCodeCoverage]
public class UnknownErrorTests
{
    [Fact]
    public void Should_CreateErrorWithProvidedMessageAndStatusCode()
    {
        // -- Arrange
        string message = "Something went wrong";

        // -- Act
        CustomError customError = CustomError.UnknownError(message);

        // -- Assert
        customError.Code.Should().Be(ErrorCodes.UnknownError);
        customError.Should().BeEquivalentTo(new CustomError(ErrorCodes.UnknownError,
            new CustomErrorInformation("Something went wrong")));
    }

    [Fact]
    public void None_ShouldHaveNothingCodeAndDefaultInformation()
    {
        // -- Arrange

        // -- Act
        CustomError error = CustomError.None;

        // -- Assert
        error.Code.Should().Be(ErrorCodes.Nothing);
        error.CustomErrorInformation.Should().NotBeNull();
        error.CustomErrorInformation.Message.Should().BeEmpty();
        error.CustomErrorInformation.Owner.Should().BeEquivalentTo("Raven");
        error.CustomErrorInformation.AppName.Should().BeEquivalentTo("Media Collection");
    }
}
