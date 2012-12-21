using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAssertions.Mvc3.Tests.Helpers;

namespace FluentAssertions.Mvc3.Tests
{
    [TestFixture]
    class FailureMessageHelper_Tests
    {
        [Test]
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

        [Test]
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
    }
}
