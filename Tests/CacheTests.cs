using NAoCHelper;
using NUnit.Framework;
using Shouldly;

namespace NAoCHelperTests
{
    public class CacheTests
    {
        [Test]
        public void GetInputReturnsNothingForEmptyCache()
        {
            // Arrange
            var cache = new Cache();

            // Act
            var result = cache.GetInput(2019, 1);

            // Assert
            result.ShouldBeNullOrWhiteSpace();
        }
    }
}