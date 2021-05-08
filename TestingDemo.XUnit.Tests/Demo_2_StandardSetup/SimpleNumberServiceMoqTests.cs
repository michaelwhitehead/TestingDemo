using System;
using System.Collections.Generic;
using Moq;
using TestingDemo.Demo_2;
using TestingDemo.Services.Interfaces;
using Xunit;

namespace TestingDemo.XUnit.Tests.Demo_2_StandardSetup
{
    public class SimpleNumberServiceMoqTests
    {
        private Mock<ILogger> _loggerMock;

        private SimpleNumberService Sut { get; }

        public SimpleNumberServiceMoqTests()
        {
            _loggerMock = new Mock<ILogger>();
            Sut = new SimpleNumberService(_loggerMock.Object);
        }

        [Fact]
        public void CheckForPositiveNumber_ShouldReturnTrue_WhenPositiveNumber()
        {
            // Arrange
            var number = "2";

            // Act
            var actual = Sut.CheckForPositiveNumber(number);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void CheckForPositiveNumber_ShouldReturnFalse_WhenNegativeNumber()
        {
            // Arrange
            var number = "-2";

            // Act
            var actual = Sut.CheckForPositiveNumber(number);

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void CheckForPositiveNumber_ShouldReturnFalse_WhenNotNumber()
        {
            // Arrange
            var number = "helloWorld";

            // Act
            var actual = Sut.CheckForPositiveNumber(number);

            // Assert
            Assert.False(actual);
            _loggerMock.Verify(c => c.LogError(It.IsAny<Exception>(), It.IsAny<Dictionary<string, string>>()), Times.Once);
        }
    }
}
