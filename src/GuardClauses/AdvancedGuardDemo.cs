using GuardClauses.AdvancedGuards.Examples;

namespace GuardClauses;

public class AdvancedGuardDemo
{
    public static async Task RunAsync()
    {
        Console.WriteLine("Advanced Guard Clauses Demo");
        Console.WriteLine("===========================");
        
        await AdvancedGuardExamples.RunAllExamples();
        
        Console.WriteLine("\nDemo completed!");
    }
}