using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Model.Common.Implementations;
using Xunit;


namespace Bank.Model.Test.ValidatorTest
{
    public class IsValidChoiceTest : IClassFixture<ConsoleUserInput>
    {
        // Setup 

        private readonly ConsoleUserInput validator;

        public IsValidChoiceTest(ConsoleUserInput validator)
        {
            this.validator = validator;
        }


        [Fact]
        public void IsValidChoice_ValidInput_ReturnsTrue()
        {
            // Arrange
            //var validator = new ConsoleUserInput();

            // Act
            bool isValid = validator.IsValidChoice("5");

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidChoice_InvalidInput_ReturnsFalse()
        {
            // Arrange
            //var validator = new ConsoleUserInput();

            // Act
            bool isValid = validator.IsValidChoice("abc");

            // Assert
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("5", true)]     // Valid input
        [InlineData("10", true)]   // Valid input
        [InlineData("abc", false)]  // Invalid input
        [InlineData("3.14", false)] // Invalid input
        [InlineData("-10", false)]   // Invalid input
        [InlineData("", false)]     // Invalid input
        public void IsValidChoice_Input_ReturnsExpectedResult(string input, bool expectedResult)
        {
            // Arrange
            //var validator = new ConsoleUserInput();

            // Act
            bool isValid = validator.IsValidChoice(input);

            // Assert
            Assert.Equal(expectedResult, isValid);
        }
    }
}
