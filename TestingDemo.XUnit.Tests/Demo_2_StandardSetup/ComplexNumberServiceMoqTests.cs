using System;
using System.Collections.Generic;
using Moq;
using TestingDemo.Demo_2;
using TestingDemo.Services.Interfaces;
using Xunit;

namespace TestingDemo.XUnit.Tests.Demo_2_StandardSetup
{
    public class ComplexNumberServiceMoqTests
    {
        private Mock<IBaseServices> _baseServiceMock;

        private ComplexNumberService Sut { get; }

        public ComplexNumberServiceMoqTests()
        {
            _baseServiceMock = new Mock<IBaseServices>() { DefaultValue = DefaultValue.Mock };
            Sut = new ComplexNumberService(_baseServiceMock.Object);
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
            _baseServiceMock.Verify(c => c.Logger.LogError(It.IsAny<Exception>(), It.IsAny<Dictionary<string, string>>()), Times.Once);
        }
    }
}
