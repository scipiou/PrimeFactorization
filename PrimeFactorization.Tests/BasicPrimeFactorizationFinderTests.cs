using System.Collections.Generic;
using PrimeFactorization.ConsoleApp.PrimeFactorizationFinders;
using Xunit;

namespace PrimeFactorization.Tests
{
    public class BasicPrimeFactorizationFinderTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void PrimeFactorization_ReturnCorrectResults(ulong number, ulong[] expectedResult)
        {
            // Arrange

            var factFinder = new BasicPrimeFactorizationFinder();

            // Act

            var result = factFinder.FindPrimeFactorization(number);

            // Assert

            Assert.Equal(expectedResult, result);

        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 2ul, new ulong[] {2}},
                new object[] { 3ul, new ulong[] {3}},
                new object[] { 4ul, new ulong[] {2, 2}},
                new object[] { 121ul, new ulong[] {11, 11}},
                new object[] { 123456ul, new ulong[] { 2, 2, 2, 2, 2, 2, 3, 643 } },
                new object[] { 56234ul, new ulong[] { 2, 31, 907 } },
                new object[] { 8121ul, new ulong[] { 3, 2707 } },
                new object[] { 123457ul, new ulong[] { 123457 } },
                new object[] { 1000003ul, new ulong[] { 1000003 } },
                new object[] { 99000047ul, new ulong[] { 99000047 } },
                new object[] { 9899359999ul, new ulong[] { 9899359999 } },
                new object[] { 1048576ul, new ulong[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 } },
                new object[] { 200560490130ul, new ulong[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 } }
            };

    }
}
