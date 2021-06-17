using System.Collections.Generic;

namespace PrimeFactorization.ConsoleApp
{
    public class FactorizationResult
    {
        public ulong Number { get; set; }

        public IReadOnlyCollection<ulong> PrimeFactors { get; set; }

        public bool IsError { get; set; } = false;
    }
}