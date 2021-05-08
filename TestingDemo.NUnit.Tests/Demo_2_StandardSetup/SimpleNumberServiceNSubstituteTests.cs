using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TestingDemo.Demo_2;
using TestingDemo.Services.Interfaces;

namespace TestingDemo.NUnit.Tests.Demo_2_StandardSetup
{
    public class SimpleNumberServiceNSubstituteTests
    {
        private ILogger _loggerMock;

        private SimpleNumberService Sut { get; }

        public SimpleNumberServiceNSubstituteTests()
        {
            _loggerMock = Substitute.For<ILogger>();
            Sut = new SimpleNumberService(_loggerMock);
        }

        [Test]
        public void CheckForPositiveNumber_ShouldReturnTrue_WhenPositiveNumber()
        {
            // Arrange
            var number = "2";

            // Act
            var actual = Sut.CheckForPositiveNumber(number);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void CheckForPositiveNumber_ShouldReturnFalse_WhenNegativeNumber()
        {
            // Arrange
            var number = "-2";

            // Act
            var actual = Sut.CheckForPositiveNumber(number);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void CheckForPositiveNumber_ShouldReturnFalse_WhenNotNumber()
        {
            // Arrange
            var number = "helloWorld";

            // Act
            var actual = Sut.CheckForPositiveNumber(number);

            // Assert
            Assert.False(actual);
            _loggerMock.Received(1).LogError(Arg.Any<Exception>(), Arg.Any<Dictionary<string, string>>());
        }
    }
}
