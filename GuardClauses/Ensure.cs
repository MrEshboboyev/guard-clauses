namespace GuardClauses;

public static class Ensure
{
    public static void NotNull<T>(T? value, string? paramName = null)
    {
        if (value is null) throw new ArgumentNullException(
            "The value cannot be null",
            paramName);
    }
    
    public static void NotNullOrEmpty(string? value, string? paramName = null)
    {
        if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(
            "The string cannot be null nor empty", 
            paramName);
    }
    
    public static void NotNullOrEmptyList<T>(List<T>? list, string? paramName = null)
    {
        if (list is null || list.Count == 0)
        {
            throw new ArgumentException("The list should contain at least 1 item.", paramName);
        }
    }
}
