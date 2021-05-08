using System;
using System.Threading.Tasks;
using TestingDemo.Helpers;
using Xunit;

namespace TestingDemo.XUnit.Tests.Other
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1642:Constructor summary documentation should begin with standard text", Justification = "Only for Demo purposes")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Only for Demo purposes")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Only for Demo purposes")]
    public class TestsFixture : IDisposable
    {
        /// <summary>
        /// Do "global" initialization here; Only called once.
        /// </summary>
        public TestsFixture()
        {
            WriteOutput.Reset("Demo_1_XUnit");
            WriteOutput.WriteToFile("Demo_1_XUnit", "TestsFixture.ctor");
        }

        /// <summary>
        /// Do "global" teardown here; Only called once.
        /// </summary>
        public void Dispose()
        {
            WriteOutput.WriteToFile("Demo_1_XUnit", "TestsFixture.Dispose");
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1642:Constructor summary documentation should begin with standard text", Justification = "Only for Demo purposes")]
    public class SetupTearDownTests : IClassFixture<TestsFixture>, IDisposable
    {
        /// <summary>
        /// Called before every Test.
        /// </summary>
        public SetupTearDownTests()
        {
            WriteOutput.WriteToFile("Demo_1_XUnit", "SetupTearDownTests.ctor");
        }

        /// <summary>
        /// Called after every Test.
        /// </summary>
        public void Dispose()
        {
            WriteOutput.WriteToFile("Demo_1_XUnit", "SetupTearDownTests.Dispose");
        }

        [Fact]
        public void Synchronous_Test()
        {
            // Arrange

            // Act
            WriteOutput.WriteToFile("Demo_1_XUnit", "SetupTearDownTests.Synchronous_Test");

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async Task Asynchronous_Test()
        {
            // Arrange

            // Act
            await Task.Delay(0);
            WriteOutput.WriteToFile("Demo_1_XUnit", "SetupTearDownTests.Asynchronous_Test");

            // Assert
            Assert.True(true);
        }

        [Theory]
        [InlineData("value", false)]
        [InlineData("", true)]
        /// <summary>
        /// Called as many times as there are InlineData attributes.
        /// </summary>
        public void Multiple_Test(string input, bool expected)
        {
            // Arrange

            // Act
            WriteOutput.WriteToFile("Demo_1_XUnit", $"SetupTearDownTests.Multiple_Test (input:{input}) (expected:{expected})");

            // Assert
            Assert.Equal(expected, string.IsNullOrEmpty(input));
        }
    }
}
