using GuardClauses.AdvancedGuards.Exceptions;

namespace GuardClauses.AdvancedGuards.Attributes;

/// <summary>
/// Attribute to validate that a numeric property is within a range
/// </summary>
public class RangeAttribute : GuardAttribute
{
    private readonly object _min;
    private readonly object _max;

    /// <summary>
    /// Initializes a new instance of the RangeAttribute class
    /// </summary>
        public RangeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public RangeAttribute(double min, double max)
        {
            _min = min;
            _max = max;
        }

        public RangeAttribute(decimal min, decimal max)
        {
            _min = min;
            _max = max;
        }

    /// <summary>
    /// Validates that the numeric value is within the specified range
    /// </summary>
    public override void Validate(object? value, string propertyName)
    {
        switch (value)
        {
            case int intValue:
                if (_min is int minInt && _max is int maxInt && (intValue < minInt || intValue > maxInt))
                    throw new ValidationException($"The value must be between {minInt} and {maxInt}", propertyName);
                break;
            case double doubleValue:
                if (_min is double minDouble && _max is double maxDouble && (doubleValue < minDouble || doubleValue > maxDouble))
                    throw new ValidationException($"The value must be between {minDouble} and {maxDouble}", propertyName);
                break;
            case decimal decimalValue:
                if (_min is decimal minDecimal && _max is decimal maxDecimal && (decimalValue < minDecimal || decimalValue > maxDecimal))
                    throw new ValidationException($"The value must be between {minDecimal} and {maxDecimal}", propertyName);
                break;
            case long longValue:
                if (_min is long minLong && _max is long maxLong && (longValue < minLong || longValue > maxLong))
                    throw new ValidationException($"The value must be between {minLong} and {maxLong}", propertyName);
                break;
            case float floatValue:
                if (_min is float minFloat && _max is float maxFloat && (floatValue < minFloat || floatValue > maxFloat))
                    throw new ValidationException($"The value must be between {minFloat} and {maxFloat}", propertyName);
                break;
        }
    }
}