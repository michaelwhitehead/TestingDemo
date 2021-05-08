using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TestingDemo.Helpers;

namespace TestingDemo.NUnit.Tests.Other
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1642:Constructor summary documentation should begin with standard text", Justification = "Only for Demo purposes")]
    public class SetupTearDownTests
    {
        /// <summary>
        /// Do "global" initialization here; Only called once.
        /// </summary>
        public SetupTearDownTests()
        {
            WriteOutput.Reset("Demo_1_NUnit");
            WriteOutput.WriteToFile("Demo_1_NUnit", "SetupTearDownTests.ctor");
        }

        [SetUp]
        /// <summary>
        /// Called before every Test.
        /// </summary>
        public void Setup()
        {
            WriteOutput.WriteToFile("Demo_1_NUnit", "SetupTearDownTests.Setup");
        }

        [TearDown]
        /// <summary>
        /// Called after every Test.
        /// </summary>
        public void TearDown()
        {
            WriteOutput.WriteToFile("Demo_1_NUnit", "SetupTearDownTests.TearDown");
        }

        [Test]
        public void Synchronous_Test()
        {
            // Arrange

            // Act
            WriteOutput.WriteToFile("Demo_1_NUnit", "SetupTearDownTests.Synchronous_Test");

            // Assert
            Assert.True(true);
        }

        [Test]
        public async Task Asynchronous_Test()
        {
            // Arrange

            // Act
            await Task.Delay(0);
            WriteOutput.WriteToFile("Demo_1_NUnit", "SetupTearDownTests.Asynchronous_Test");

            // Assert
            Assert.Pass();
        }

        [Datapoints]
        public IEnumerable<(string input, bool expected)> Input
        {
            get
            {
                return new (string input, bool expected)[]
                {
                    ("someValue", false),
                    ("", true),
                };
            }
        }

        [Theory]
        /// <summary>
        /// Called as many times as there are InlineData attributes.
        /// </summary>
        public void Multiple_Test((string input, bool expected) dataPoints)
        {
            // Arrange

            // Act
            WriteOutput.WriteToFile("Demo_1_NUnit", $"SetupTearDownTests.Multiple_Test (input:{dataPoints.input}) (expected:{dataPoints.expected})");

            // Assert
            Assert.AreEqual(dataPoints.expected, string.IsNullOrEmpty(dataPoints.input));
        }
    }
}
