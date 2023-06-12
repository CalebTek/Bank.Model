using Bank.Model.Common.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Test.ValidatorTest
{
    public class IsValidAmountTest
    {
        [Theory]
        [InlineData("0", false)]            // Invalid: Amount is 0
        [InlineData("-10", false)]          // Invalid: Amount is negative
        [InlineData("abc", false)]          // Invalid: Not a valid decimal
        [InlineData("", false)]             // Invalid: Empty input
        [InlineData("12.34", true)]         // Valid: Positive decimal amount
        [InlineData("1000.00", true)]       // Valid: Positive decimal amount
        public void IsValidAmount_Input_ReturnsExpectedResult(string input, bool expectedResult)
        {
            // Arrange
            var validator = new ConsoleUserInput();

            // Act
            bool isValid = validator.IsValidAmount(input);

            // Assert
            Assert.Equal(expectedResult, isValid);
        }
    }
}
