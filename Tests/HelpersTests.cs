using System;
using NAoCHelper;
using NUnit.Framework;
using Shouldly;

namespace NAoCHelperTests
{
    public class HelpersTests
    {
        [Test]
        public void ShouldGetCookieFromAppSettings()
        {
            // Arrange

            // Act
            var secret = Helpers.GetCookie("whatever");

            // Assert
            secret.ShouldBe("Configured in User Secrets");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ShouldThrowIfCookieGuidIsInvalid(string param)
        {
            // Arrange

            // Act

            // Assert
            Should.Throw<ArgumentNullException>(() => Helpers.GetCookie(param));
        }
    }
}