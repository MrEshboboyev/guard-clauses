using NUnit.Framework;

namespace GuardClauses.UnitTests;

public class EnsureTests
{
    [Test]
    public void NotNull_WhenValueIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        string? value = null;

        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(value));
        Assert.That(ex.ParamName, Is.EqualTo("value"));
        Assert.That(ex.Message, Does.Contain("The value cannot be null"));
    }

    [Test]
    public void NotNull_WhenValueIsNotNull_ReturnsValue()
    {
        // Arrange
        string value = "test";

        // Act
        var result = Ensure.NotNull(value);

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void NotNullOrEmpty_WhenValueIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        string? value = null;

        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(value));
        Assert.That(ex.ParamName, Is.EqualTo("value"));
        Assert.That(ex.Message, Does.Contain("The string cannot be null nor empty"));
    }

    [Test]
    public void NotNullOrEmpty_WhenValueIsEmpty_ThrowsArgumentNullException()
    {
        // Arrange
        string value = "";

        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(value));
        Assert.That(ex.ParamName, Is.EqualTo("value"));
        Assert.That(ex.Message, Does.Contain("The string cannot be null nor empty"));
    }

    [Test]
    public void NotNullOrEmpty_WhenValueIsValid_ReturnsValue()
    {
        // Arrange
        string value = "test";

        // Act
        var result = Ensure.NotNullOrEmpty(value);

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void NotNullOrEmptyList_WhenListIsNull_ThrowsArgumentException()
    {
        // Arrange
        List<string>? list = null;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmptyList(list));
        Assert.That(ex.ParamName, Is.EqualTo("list"));
        Assert.That(ex.Message, Does.Contain("The list should contain at least 1 item"));
    }

    [Test]
    public void NotNullOrEmptyList_WhenListIsEmpty_ThrowsArgumentException()
    {
        // Arrange
        List<string> list = new();

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmptyList(list));
        Assert.That(ex.ParamName, Is.EqualTo("list"));
        Assert.That(ex.Message, Does.Contain("The list should contain at least 1 item"));
    }

    [Test]
    public void NotNullOrEmptyList_WhenListHasItems_ReturnsList()
    {
        // Arrange
        List<string> list = new() { "item1", "item2" };

        // Act
        var result = Ensure.NotNullOrEmptyList(list);

        // Assert
        Assert.That(result, Is.EqualTo(list));
    }

    [Test]
    public void NotNegative_WhenValueIsNegative_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        int value = -5;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.NotNegative(value));
        Assert.That(ex.ParamName, Is.EqualTo("value"));
        Assert.That(ex.Message, Does.Contain("The value cannot be negative"));
    }

    [Test]
    public void NotNegative_WhenValueIsZero_ReturnsValue()
    {
        // Arrange
        int value = 0;

        // Act
        var result = Ensure.NotNegative(value);

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void NotNegative_WhenValueIsPositive_ReturnsValue()
    {
        // Arrange
        int value = 5;

        // Act
        var result = Ensure.NotNegative(value);

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void InRange_WhenValueIsBelowRange_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        int value = 5;
        int min = 10;
        int max = 20;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.InRange(value, min, max));
        Assert.That(ex.ParamName, Is.EqualTo("value"));
        Assert.That(ex.Message, Does.Contain($"The value must be between {min} and {max}"));
    }

    [Test]
    public void InRange_WhenValueIsAboveRange_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        int value = 25;
        int min = 10;
        int max = 20;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.InRange(value, min, max));
        Assert.That(ex.ParamName, Is.EqualTo("value"));
        Assert.That(ex.Message, Does.Contain($"The value must be between {min} and {max}"));
    }

    [Test]
    public void InRange_WhenValueIsInRange_ReturnsValue()
    {
        // Arrange
        int value = 15;
        int min = 10;
        int max = 20;

        // Act
        var result = Ensure.InRange(value, min, max);

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }
}
