using PrimeFactorization.ConsoleApp.Output.Interfaces;

namespace PrimeFactorization.ConsoleApp.Output
{
    public class RichBasicFormatter : IFileOutputLinesFormatter
    {
        public string Format(FactorizationResult factResult)
        {
            return factResult.IsError 
                ? "error" 
                : $"{factResult.Number}:{string.Join(',', factResult.PrimeFactors)}";
        }

        public string FormatSuffix => "_number_factors";
    }
}