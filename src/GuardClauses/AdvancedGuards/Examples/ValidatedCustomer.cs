using GuardClauses.AdvancedGuards.Attributes;

namespace GuardClauses.AdvancedGuards.Examples;

/// <summary>
/// Customer class with attribute-based validation
/// </summary>
public class ValidatedCustomer
{
    [NotNull]
    [NotEmpty]
    public string Name { get; set; } = string.Empty;

    [Range(13, 120)]
    public int Age { get; set; }

    [NotNull]
    [NotEmpty]
    public string Email { get; set; } = string.Empty;

    public ValidatedCustomer(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
    }

    /// <summary>
    /// Validates the customer object using attributes
    /// </summary>
    public void Validate()
    {
        ObjectValidator.Validate(this);
    }
}