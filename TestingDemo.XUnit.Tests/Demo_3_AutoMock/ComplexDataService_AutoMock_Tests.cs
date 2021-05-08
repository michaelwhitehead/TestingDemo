using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using TestingDemo.Demo_3;
using TestingDemo.Services.Interfaces;
using Xunit;

namespace TestingDemo.XUnit.Tests.Demo_3_AutoMock
{
    public class ComplexDataService_AutoMock_Tests
    {
        private AutoMocker Mocker { get; }

        private ComplexDataService Sut { get; }

        public ComplexDataService_AutoMock_Tests()
        {
            Mocker = new AutoMocker(Moq.MockBehavior.Default, Moq.DefaultValue.Mock);
            Sut = Mocker.CreateInstance<ComplexDataService>();
        }

        [Fact]
        public async Task GetDataAsync_ShouldReturnEmptyString_WhenSecureStorageThrowsException()
        {
            // Arrange
            Mocker.GetMock<ISecureStorage>().Setup(c => c.GetDataAsync(It.IsAny<string>())).Throws<Exception>();

            // Act
            var actual = await Sut.GetDataAsync();

            // Assert
            Assert.Empty(actual);
            Mocker.GetMock<ILogger>().Verify(c => c.LogError(It.IsAny<Exception>(), It.IsAny<Dictionary<string, string>>()), Times.Once);
        }
    }
}
