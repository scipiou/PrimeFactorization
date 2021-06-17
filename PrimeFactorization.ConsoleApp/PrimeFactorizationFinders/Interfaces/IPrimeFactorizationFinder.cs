using System.Collections.Generic;

namespace PrimeFactorization.ConsoleApp.PrimeFactorizationFinders.Interfaces
{
    public interface IPrimeFactorizationFinder
    {
        IReadOnlyCollection<ulong> FindPrimeFactorization(ulong number);
    }
}
