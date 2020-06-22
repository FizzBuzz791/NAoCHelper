using System;
using System.Collections.Generic;
using NAoCHelper;
using NUnit.Framework;
using Shouldly;

namespace NAoCHelperTests
{
    public class PuzzleTests
    {
        private const int VALID_YEAR = 2020;
        private const int VALID_DAY = 1;

        [Test]
        public void ConstructorThrowsForInvalidUserParameter()
        {
            // Arrange

            // Act

            // Assert
            Should.Throw<ArgumentNullException>(() => new Puzzle(null, VALID_YEAR, VALID_DAY));
        }

        [TestCaseSource(nameof(InvalidDateCases))]
        public void ConstructorThrowsForInvalidDateParameters(int year, int day)
        {
            // Arrange

            // Act

            // Assert
            Should.Throw<ArgumentOutOfRangeException>(() => new Puzzle(new User("1234"), year, day));
        }

        private static IEnumerable<object[]> InvalidDateCases()
        {
            yield return new object[] { -1, VALID_DAY };
            yield return new object[] { DateTime.Now.Year + 1, VALID_DAY };
            yield return new object[] { VALID_YEAR, -1 };
            yield return new object[] { VALID_YEAR, 28 };
        }
    }
}