using Bank.Model.Common.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Test.ValidatorTest
{
    public class IsValidAccountNumberTest
    {
        [Theory]
        [InlineData("", false)]        // Empty account number
        [InlineData("1234567890", true)]     // Valid account number
        [InlineData("12345678900", false)]     // Invalid account number length
        [InlineData("123456", false)]  // Invalid account number length and format
        [InlineData("abc", false)]     // Invalid account number length and format
        [InlineData("   ", false)]     // Invalid account number length and format
        [InlineData("lk.slie093", false)]     // Invalid account number format
        [InlineData("ABC1234567", false)]     // Invalid account number format
        public void IsValidAccountNumber_Input_ReturnsExpectedResult(string accountNumber, bool expectedResult)
        {
            // Arrange
            var validator = new ConsoleUserInput();

            // Act
            bool isValid = validator.IsValidAccountNumber(accountNumber);

            // Assert
            Assert.Equal(expectedResult, isValid);
        }
    }
}
