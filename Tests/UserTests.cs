using System;
using NAoCHelper;
using NUnit.Framework;
using Shouldly;

namespace NAoCHelperTests
{
    public class UserTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ConstructorThrowsForInvalidParameter(string param)
        {
            // Arrange

            // Act

            // Assert
            Should.Throw<ArgumentNullException>(() => new User(param));
        }
    }
}