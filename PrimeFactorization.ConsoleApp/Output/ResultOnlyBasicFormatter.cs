using PrimeFactorization.ConsoleApp.Output.Interfaces;

namespace PrimeFactorization.ConsoleApp.Output
{
    public class ResultOnlyBasicFormatter : IFileOutputLinesFormatter
    {
        public string Format(FactorizationResult factResult)
        {
            return factResult.IsError ? "error" : string.Join(',', factResult.PrimeFactors);
        }

        public string FormatSuffix => "_factors";
    }
}
