using Xunit;
using System;
using System.IO;
using Bank.Model.Common.Implementations;

namespace Bank.Model.Test.ValidatorTest
{
    public class GetChoiceTest
    {
        [Theory]
        [InlineData(5,"3")]
        [InlineData(2,"1")]
        [InlineData(7,"7")]
        public void GetChoice_ValidInput_ReturnsChoice(int max, string Input)
        {
            // Arrange
            int expectedChoice = Convert.ToInt32(Input);
            string input = Input + Environment.NewLine;
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput
            int actualChoice = userInput.GetChoice(max);

            // Assert
            Assert.Equal(expectedChoice, actualChoice);
        }

        [Theory]
        [InlineData(5,3, "abc")]
        [InlineData(9, 4, "10.89")]
        [InlineData(3, 1, "!")]
        public void GetChoice_InvalidInputThenValidInput_ReturnsValidChoice(int max, int expected ,string Input)
        {
            // Arrange
            int expectedChoice = expected;
            string input = Input + Environment.NewLine + expected.ToString() + Environment.NewLine;
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput
            int actualChoice = userInput.GetChoice(max);

            // Assert
            Assert.Equal(expectedChoice, actualChoice);
        }

        //[Fact]
        [Theory]
        [InlineData(5,4,"6")]
        [InlineData(7, 7,"9")]
        [InlineData(8, 8,"10")]
        [InlineData(2, 1, "5")]

        public void GetChoice_InputOutOfRangeThenValidInput_ReturnsValidChoice(int max, int expected, string Input)
        {
            // Arrange
            int expectedChoice = expected;
            string input = Input + Environment.NewLine + expected.ToString() + Environment.NewLine;
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput
            int actualChoice = userInput.GetChoice(max);

            // Assert
            Assert.Equal(expectedChoice, actualChoice);
        }
    }
}
