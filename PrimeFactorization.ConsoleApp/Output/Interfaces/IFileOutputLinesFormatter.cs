namespace PrimeFactorization.ConsoleApp.Output.Interfaces
{
    public interface IFileOutputLinesFormatter
    {
        string Format(FactorizationResult factResult);

        string FormatSuffix { get; } 
    }
}
