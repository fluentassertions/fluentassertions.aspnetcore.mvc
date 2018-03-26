using FluentAssertions.Mvc.Tests.Helpers;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class FailureMessageHelper_Tests
    {
        #region Public Methods

        [Fact]
        public void FailureMessageHelper_WithOneArg_Formats()
        {
            // Arrange
            var message = "Test failure message {0}.";
            var value = "reason";

            var expected = "Test failure message \"reason\".";

            // Act
            var result = FailureMessageHelper.Format(message, value);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void FailureMessageHelper_WithMultipleArgs_Formats()
        {
            // Arrange
            var message = "Test failure message {0}, {1}, {2}.";
            var reason1 = "reason one";
            var reason2 = "reason two";
            var reason3 = "reason three";

            var expected = "Test failure message \"reason one\", \"reason two\", \"reason three\".";

            // Act
            var result = FailureMessageHelper.Format(message, reason1, reason2, reason3);

            // Assert
            result.Should().Be(expected);
        }

        #endregion Public Methods
    }
}