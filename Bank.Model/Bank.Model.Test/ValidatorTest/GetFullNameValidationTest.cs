using Bank.Model.Common.Implementations;
using Xunit;

namespace Bank.Model.Test.ValidatorTest
{
    public class GetFullNameValidationTests
    {
        [Theory]
        [InlineData("John Wesley", true)] // Valid full name with two words
        [InlineData("John   Wesley", true)] // Valid full name with two words and more than one space 
        [InlineData(" John   Wesley ", true)] // Valid full name with two words and more than one space at the start and end 
        [InlineData("John", false)] // Invalid full name with one word
        [InlineData("", false)] // Empty full name
        [InlineData("JohnWesley", false)] // Invalid full name with one word
        public void GetFullName_ValidatesFullNameCorrectly(string fullName, bool expectedResult)
        {
            // Arrange
            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput

            // Act
            bool isValid = userInput.IsValidFullName(fullName);

            // Assert
            Assert.Equal(expectedResult, isValid);
        }
    }
}
