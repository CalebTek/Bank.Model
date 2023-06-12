using Xunit;
using System;
using System.IO;
using Bank.Model.Common.Implementations;
using Xunit.Abstractions;

namespace Bank.Model.Test.ValidatorTest
{
    public class GetAccountNumber
    {
        [Fact]
        public void GetAccountNumber_ValidInput_ReturnsAccountNumber()
        {
            // Arrange
            string expectedAccountNumber = "1234567890";
            string input = "1234567890" + Environment.NewLine;
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var userInput = new ConsoleUserInput(); //  ConsoleUserInput implements IValidateInput
            string actualAccountNumber = userInput.GetAccountNumber();

            // Assert
            Assert.Equal(expectedAccountNumber, actualAccountNumber);
        }

        [Fact]
        public void GetAccountNumber_EmptyInputThenValidInput_ReturnsValidAccountNumber()
        {
            // Arrange
            string expectedAccountNumber = "9876543210";
            string input = "" + Environment.NewLine + "9876543210" + Environment.NewLine;
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var userInput = new ConsoleUserInput(); //  ConsoleUserInput implements IValidateInput
            string actualAccountNumber = userInput.GetAccountNumber();

            // Assert
            Assert.Equal(expectedAccountNumber, actualAccountNumber);
        }

        //[Fact]
        //public void GetAccountNumber_InputLengthNotEqualToTenThenValidInput_ReturnsValidAccountNumber()
        //{
        //    // Arrange
        //    string expectedAccountNumber = "111222333";
        //    string invalidAccountNumber = "111";
        //    string validAccountNumber = "111222333";

        //    // Redirect console output
        //    StringWriter stringWriter = new StringWriter();
        //    Console.SetOut(stringWriter);

        //    // Prepare console input
        //    StringReader stringReader;
        //    string consoleInput;

        //    // Act - Test with invalid input
        //    consoleInput = invalidAccountNumber + Environment.NewLine;
        //    stringReader = new StringReader(consoleInput);
        //    Console.SetIn(stringReader);

        //    var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput
        //    string actualAccountNumber = userInput.GetAccountNumber();

        //    // Assert
        //    Assert.Equal(expectedAccountNumber, actualAccountNumber);

        //    // Act - Test with valid input
        //    consoleInput = validAccountNumber + Environment.NewLine;
        //    stringReader = new StringReader(consoleInput);
        //    Console.SetIn(stringReader);

        //    actualAccountNumber = userInput.GetAccountNumber();

        //    // Assert
        //    Assert.Equal(expectedAccountNumber, actualAccountNumber);

        //    // Reset console input and output
        //    Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        //    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        //}
    }
}
