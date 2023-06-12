using Xunit;
using Moq;
using Bank.Model.Common.Interfaces;

namespace Bank.Model.Test.ValidatorTest
{
    public class GetAmountValidationTests
    {
        [Theory]
        [InlineData("Enter your amount: ", "100.50", 100.50)] // Valid decimal input
        [InlineData("Enter your amount: ", "100", 100)] // Valid integer input
        [InlineData("Enter your amount: ", "0", 0)] // Valid integer input
        [InlineData("Enter your amount: ", "-1", -1)] // Valid integer input
        public void GetAmount_ValidatesAmountCorrectly(string prompt, string input, decimal expectedAmount)
        {
            // Arrange
            var userInputMock = new Mock<IValidateInput>();
            userInputMock.Setup(u => u.GetAmount(prompt)).Returns(decimal.Parse(input));
            var userInput = userInputMock.Object;

            // Act
            decimal amount = userInput.GetAmount(prompt);

            // Assert
            Assert.Equal(expectedAmount, amount);
        }

        [Theory]
        [InlineData("Enter your amount: ", "abc")]
        [InlineData("Enter your amount: ", "12abc")]
        [InlineData("Enter your amount: ", "12.0M")]
        public void GetAmount_ValidatesAmountCorrectly_InvalidInput(string prompt, string input)
        {
            // Arrange
            var userInputMock = new Mock<IValidateInput>();
            userInputMock.Setup(u => u.GetAmount(prompt)).Throws<FormatException>(); // Specify the exception type
            var userInput = userInputMock.Object;

            // Act and Assert
            Assert.Throws<FormatException>(() => userInput.GetAmount(prompt));
        }

    }
}
