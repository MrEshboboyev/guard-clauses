using NUnit.Framework;
using GuardClauses.AdvancedGuards;
using GuardClauses.AdvancedGuards.Exceptions;
using GuardClauses.AdvancedGuards.Attributes;
using GuardClauses.AdvancedGuards.Examples;

namespace GuardClauses.UnitTests;

public class AdvancedGuardTests
{
    [Test]
    public void FluentGuard_ForValidValue_ReturnsValue()
    {
        // Arrange
        string value = "test";

        // Act
        var result = Guard.For(value).NotNull().Value;

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void FluentGuard_ForNullValue_ThrowsArgumentNullException()
    {
        // Arrange
        string? value = null;

        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => Guard.For(value).NotNull());
        Assert.That(ex.ParamName, Is.EqualTo("value"));
        Assert.That(ex.Message, Does.Contain("The value cannot be null"));
    }

    [Test]
    public void FluentGuardWithCustomExceptions_ForNullValue_ThrowsValidationException()
    {
        // Arrange
        string? value = null;

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => GuardWithCustomExceptions.For(value).NotNull());
        Assert.That(ex.ParamName, Is.EqualTo("value"));
        Assert.That(ex.Message, Does.Contain("The value cannot be null"));
    }

    [Test]
    public void CollectionGuards_ForNullOrEmptyCollection_ThrowsValidationException()
    {
        // Arrange
        List<string>? collection = null;

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => collection.NotNullOrEmpty());
        Assert.That(ex.Message, Does.Contain("The collection cannot be null"));
    }

    [Test]
    public void CollectionGuards_ForEmptyCollection_ThrowsValidationException()
    {
        // Arrange
        var collection = new List<string>();

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => collection.NotNullOrEmpty());
        Assert.That(ex.Message, Does.Contain("The collection cannot be empty"));
    }

    [Test]
    public void CollectionGuards_ForValidCollection_ReturnsCollection()
    {
        // Arrange
        var collection = new List<string> { "item1", "item2" };

        // Act
        var result = collection.NotNullOrEmpty();

        // Assert
        Assert.That(result, Is.EqualTo(collection));
    }

    [Test]
    public void CompositeGuards_ValidEmail_ReturnsEmail()
    {
        // Arrange
        string email = "user@example.com";

        // Act
        var result = CompositeGuards.ValidEmail(email);

        // Assert
        Assert.That(result, Is.EqualTo(email));
    }

    [Test]
    public void CompositeGuards_InvalidEmail_ThrowsValidationException()
    {
        // Arrange
        string email = "invalid-email";

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => CompositeGuards.ValidEmail(email));
        Assert.That(ex.Message, Does.Contain("Email address is not valid"));
    }

    [Test]
    public void StringGuards_ValidEmail_ReturnsEmail()
    {
        // Arrange
        string email = "user@example.com";

        // Act
        var result = email.ValidEmail();

        // Assert
        Assert.That(result, Is.EqualTo(email));
    }

    [Test]
    public void StringGuards_InvalidEmail_ThrowsValidationException()
    {
        // Arrange
        string email = "invalid-email";

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => email.ValidEmail());
        Assert.That(ex.Message, Does.Contain("The string is not a valid email address"));
    }

    [Test]
    public void NumericGuards_PositiveValue_ReturnsValue()
    {
        // Arrange
        int value = 5;

        // Act
        var result = value.Positive();

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void NumericGuards_NegativeValue_ThrowsValidationException()
    {
        // Arrange
        int value = -5;

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => value.Positive());
        Assert.That(ex.Message, Does.Contain("The value must be positive"));
    }

    [Test]
    public void DateTimeGuards_FutureDate_ReturnsDate()
    {
        // Arrange
        var date = DateTime.Now.AddDays(10);

        // Act
        var result = date.NotInPast();

        // Assert
        Assert.That(result, Is.EqualTo(date));
    }

    [Test]
    public void DateTimeGuards_PastDate_ThrowsValidationException()
    {
        // Arrange
        var date = DateTime.Now.AddDays(-10);

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => date.NotInPast());
        Assert.That(ex.Message, Does.Contain("The date cannot be in the past"));
    }

    [Test]
    public void AttributeBasedValidation_ValidObject_PassesValidation()
    {
        // Arrange
        var customer = new ValidatedCustomer("John Doe", 30, "john@example.com");

        // Act & Assert
        Assert.DoesNotThrow(() => customer.Validate());
    }

    [Test]
    public void AttributeBasedValidation_InvalidObject_ThrowsValidationException()
    {
        // Arrange
        var customer = new ValidatedCustomer("", -5, "invalid-email");

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => customer.Validate());
        Assert.That(ex.Message, Does.Contain("The string cannot be null nor empty"));
    }

    [Test]
    public async Task AsyncGuards_ValidValue_ReturnsValue()
    {
        // Arrange
        int value = 123;

        // Act
        var result = await AsyncGuards.SatisfiesAsync(
            value,
            async x => 
            {
                await Task.Delay(1);
                return x > 0;
            },
            "Value must be positive");

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void ObjectValidator_ValidObject_PassesValidation()
    {
        // Arrange
        var customer = new ValidatedCustomer("John Doe", 30, "john@example.com");

        // Act & Assert
        Assert.DoesNotThrow(() => ObjectValidator.Validate(customer));
    }

    [Test]
    public void ObjectValidator_InvalidObject_ThrowsValidationException()
    {
        // Arrange
        var customer = new ValidatedCustomer("", -5, "invalid-email");

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => ObjectValidator.Validate(customer));
        Assert.That(ex.Message, Does.Contain("The string cannot be null nor empty"));
    }
}