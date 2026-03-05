namespace MediaCollection.Domain.Testing.CustomResultTests;

[ExcludeFromCodeCoverage]
public class SuccessTests
{
    [Fact]
    public void Should_CreateSuccessResultWithValue()
    {
        // -- Arrange
        Apple apple = new() { Id = 555, Name = "Granny Smith's" };

        // -- Act
        CustomResult<Apple> appleResult = CustomResult<Apple>.Success(apple);

        // -- Assert
        appleResult.IsSuccess.Should().BeTrue();
        appleResult.IsFailure.Should().BeFalse();
        appleResult.Error.Should().Be(CustomError.None);
        appleResult.Value.Should().BeEquivalentTo(apple);
    }
}

[ExcludeFromCodeCoverage]
internal class Apple
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}