using Xunit;
using System;
using System.IO;
using Moq;
using Bank.Model.Common.Implementations;

namespace Bank.Model.Test.ValidatorTest
{
    public class GetPasswordTest
    {
        //[Fact]
        //public void GetPassword_EmptyInput_ReturnsEmptyPassword()
        //{
        //    // Arrange
        //    string expectedPassword = "";

        //    // Mock console input
        //    var consoleInput = new Mock<TextReader>();
        //    consoleInput.Setup(c => c.ReadLine()).Returns("");

        //    // Redirect console output
        //    StringWriter stringWriter = new StringWriter();
        //    Console.SetOut(stringWriter);

        //    // Set mock console input
        //    Console.SetIn(consoleInput.Object);

        //    var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput

        //    // Act
        //    string actualPassword = userInput.GetPassword();

        //    // Assert
        //    Assert.Equal(expectedPassword, actualPassword);

        //    // Reset console input and output
        //    Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        //    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        //}

        //[Fact]
        //public void GetPassword_MinimumLengthInput_ReturnsInvalidPassword()
        //{
        //    // Arrange
        //    string expectedPassword = "";

        //    // Mock console input
        //    var consoleInput = new Mock<TextReader>();
        //    consoleInput.Setup(c => c.ReadLine()).Returns("Ab1#");

        //    // Redirect console output
        //    StringWriter stringWriter = new StringWriter();
        //    Console.SetOut(stringWriter);

        //    // Set mock console input
        //    Console.SetIn(consoleInput.Object);

        //    var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput

        //    // Act
        //    string actualPassword = userInput.GetPassword();

        //    // Assert
        //    Assert.Equal(expectedPassword, actualPassword);

        //    // Reset console input and output
        //    Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        //    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        //}

        [Fact]
        public void GetPassword_MaximumLengthInput_ReturnsValidPassword()
        {
            // Arrange
            string expectedPassword = new string('A', 100) + "1#"; // Assuming maximum length is 103

            // Mock console input
            var consoleInput = new Mock<TextReader>();
            consoleInput.Setup(c => c.ReadLine()).Returns(expectedPassword);

            // Redirect console output
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Set mock console input
            Console.SetIn(consoleInput.Object);

            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput

            // Act
            string actualPassword = userInput.GetPassword();

            // Assert
            Assert.Equal(expectedPassword, actualPassword);

            // Reset console input and output
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        //[Fact]
        //public void GetPassword_InvalidInputThenValidInput_ReturnsValidPassword()
        //{
        //    // Arrange
        //    string expectedPassword = "Password123#";
        //    string invalidPassword = "password";
        //    string validPassword = "Password123#";

        //    // Mock console input
        //    var consoleInput = new Mock<TextReader>();
        //    consoleInput.SetupSequence(c => c.ReadLine())
        //        .Returns(invalidPassword)
        //        .Returns(validPassword);

        //    // Redirect console output
        //    StringWriter stringWriter = new StringWriter();
        //    Console.SetOut(stringWriter);

        //    // Set mock console input
        //    Console.SetIn(consoleInput.Object);

        //    var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput

        //    // Act - Test with invalid input
        //    string actualPassword = userInput.GetPassword();

        //    // Assert
        //    Assert.Equal(expectedPassword, actualPassword);

        //    // Act - Test with valid input
        //    actualPassword = userInput.GetPassword();

        //    // Assert
        //    Assert.Equal(expectedPassword, actualPassword);

        //    // Reset console input and output
        //    Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        //    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        //}

    }
}
