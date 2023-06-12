using Bank.Model.Common.Implementations;
using Xunit;

namespace Bank.Model.Test.ValidatorTest
{
    public class GetEmailValidationTest
    {
        [Theory]
        [InlineData("test@example.com", false)] // invalid email address
        [InlineData("test", false)] // Invalid email address
        [InlineData("test@example", false)] // Invalid email address
        [InlineData("test@.com", false)] // Invalid email address

        public void IsValidEmail_ValidatesWrongEmail(string input, bool expectedIsValid)
        {
            // Arrange
            var userInput = new ConsoleUserInput(); //  ConsoleUserInput implements IValidateInput

            // Act
            bool isValid = userInput.IsValidEmail(input);

            // Assert
            Assert.Equal(expectedIsValid, isValid);
        }


        [Theory]
        [InlineData("test@gmail.com", true)] // Valid email address for gmail.com
        [InlineData("test@yahoo.com", true)] // Valid email address for yahoo.com
        [InlineData("test@outlook.com", true)] // Valid email address for outlook.com
        [InlineData("test@example.com", false)] // Invalid email address
        [InlineData("test@invaliddomain.com", false)] // Invalid email address
        [InlineData("test", false)] // Invalid email address
        public void IsValidEmail_ValidatesEmailCorrectly(string input, bool expectedIsValid)
        {
            // Arrange
            var userInput = new ConsoleUserInput(); // ConsoleUserInput implements IValidateInput

            // Act
            bool isValid = userInput.IsValidEmail(input);

            // Assert
            Assert.Equal(expectedIsValid, isValid);
        }


        //[Fact]
        //public void GetEmail_ValidatesEmailCorrectly(string input, bool expectedIsValid)
        //{
        //    // Arrange
        //    var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput

        //    // Act
        //    string email = userInput.GetEmail();

        //    // Assert
        //    if (expectedIsValid)
        //    {
        //        Assert.Equal(input, email);
        //    }
        //    else
        //    {
        //        Assert.NotEqual(input, email);
        //    }
        //}
    }
}
