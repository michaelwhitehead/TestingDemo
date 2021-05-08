using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using TestingDemo.Demo_3;
using TestingDemo.Services.Interfaces;
using Xunit;

namespace TestingDemo.XUnit.Tests.Demo_3_AutoMock
{
    public class ComplexDataService_Standard_Tests
    {
        private Mock<ILogger> _loggerMock;
        private Mock<ISecureStorage> _secureStorageMock;
        private Mock<INativeSettingsService> _nativeSettingsServiceMock;
        private Mock<IPreferences> _preferencesMock;

        private ComplexDataService Sut { get; }

        public ComplexDataService_Standard_Tests()
        {
            _loggerMock = new Mock<ILogger>();
            _secureStorageMock = new Mock<ISecureStorage>();
            _nativeSettingsServiceMock = new Mock<INativeSettingsService>();
            _preferencesMock = new Mock<IPreferences>();

            Sut = new ComplexDataService(_loggerMock.Object, _secureStorageMock.Object, _nativeSettingsServiceMock.Object, _preferencesMock.Object);
        }

        [Fact]
        public async Task GetDataAsync_ShouldReturnEmptyString_WhenSecureStorageThrowsException()
        {
            // Arrange
            _secureStorageMock.Setup(c => c.GetDataAsync(It.IsAny<string>())).Throws<Exception>();

            // Act
            var actual = await Sut.GetDataAsync();

            // Assert
            Assert.Empty(actual);
            _loggerMock.Verify(c => c.LogError(It.IsAny<Exception>(), It.IsAny<Dictionary<string, string>>()), Times.Once);
        }
    }
}
