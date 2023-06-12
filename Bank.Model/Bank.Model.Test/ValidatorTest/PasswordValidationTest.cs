using Bank.Model.Common.Implementations;
using Xunit;

namespace Bank.Model.Test.ValidatorTest
{
    public class PasswordValidationTests
    {
        [Theory]
        [InlineData("Password123#", true)] // Valid password
        [InlineData("password123#", false)] // Missing uppercase letter
        [InlineData("Password123", false)] // Missing special character
        [InlineData("password", false)] // Missing uppercase letter, number, and special character
        [InlineData("P1#", false)] // Password length less than 8 characters
        [InlineData("", false)] // Empty password
        public void IsValidPassword_ValidatesPasswordCorrectly(string password, bool expectedResult)
        {
            // Arrange
            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput

            // Act
            bool isValid = userInput.IsValidPassword(password);

            // Assert
            Assert.Equal(expectedResult, isValid);
        }
    }
}
