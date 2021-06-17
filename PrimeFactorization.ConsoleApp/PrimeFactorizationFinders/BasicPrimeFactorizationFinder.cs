using System;
using System.Collections.Generic;
using PrimeFactorization.ConsoleApp.PrimeFactorizationFinders.Interfaces;

namespace PrimeFactorization.ConsoleApp.PrimeFactorizationFinders
{
    public class BasicPrimeFactorizationFinder : IPrimeFactorizationFinder
    {
        public IReadOnlyCollection<ulong> FindPrimeFactorization(ulong number)
        {
            var primeFactors = new List<ulong>();

            var sqrt = (ulong)Math.Sqrt(number);

            for (ulong i = 2; i <= sqrt; ++i)
            {
                while (number % i == 0)
                {
                    primeFactors.Add(i);
                    number = number / i;
                }

                if (number == 1)
                {
                    break;
                }
            }

            if (number > 1)
            {
                primeFactors.Add(number);
            }

            return primeFactors;
        }
    }
}
