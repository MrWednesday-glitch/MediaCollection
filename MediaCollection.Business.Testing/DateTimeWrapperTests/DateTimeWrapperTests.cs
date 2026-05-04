namespace MediaCollection.Business.Testing.DateTimeWrapperTests;

[ExcludeFromCodeCoverage]
public sealed class DateTimeWrapperTests
{
    [Fact]
    public void Should_ReturnTheCorrectNow_When_GivingAFixedOne()
    {
        // -- Arrange
        DateTimeWrapper dateTimeWrapper = new(new DateTime(2026, 5, 3));

        // -- Act

        // -- Assert
        dateTimeWrapper.Now.Year.Should().Be(2026);
        dateTimeWrapper.Now.Month.Should().Be(5);
        dateTimeWrapper.Now.Day.Should().Be(3);
    }

    [Fact]
    public void Should_ReturnTheCorrectUtcNow_When_GivingAFixedOne()
    {
        // -- Arrange
        DateTimeWrapper dateTimeWrapper = new(new DateTime(2026, 5, 3));

        // -- Act

        // -- Assert
        dateTimeWrapper.UtcNow.Year.Should().Be(2026);
        dateTimeWrapper.UtcNow.Month.Should().Be(5);
        dateTimeWrapper.UtcNow.Day.Should().Be(3);
    }
}
