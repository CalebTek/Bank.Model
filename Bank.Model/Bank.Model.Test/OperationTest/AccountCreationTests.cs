using Xunit;
using Moq;
using Bank.Model.Common.Implementations;
using Bank.Model.Common.Interfaces;
using Bank.Model.Common.Models;

namespace Bank.Model.Tests.OperationTest
{
    public class AccountCreationTests
    {
        //[Fact]
        //public void CreateAccount_ValidInputs_AddsAccountAndDisplaysDetails()
        //{
        //    // Arrange
        //    var printerMock = new Mock<IPrinter>();
        //    var banksMock = new Mock<IBank>();
        //    var validateInputMock = new Mock<IValidateInput>();
        //    var displayUIMock = new Mock<IDisplayUI>();
        //    var accountMock = new Mock<IAccount>();

        //    var userInput = new Banks(printerMock.Object, validateInputMock.Object, banksMock.Object, displayUIMock.Object, accountMock.Object);

        //    // Set up mocked input values
        //    validateInputMock.SetupSequence(v => v.GetFullName())
        //        .Returns("John Doe");
        //    validateInputMock.SetupSequence(v => v.GetPassword())
        //        .Returns("P@ssw0rd");
        //    validateInputMock.SetupSequence(v => v.GetEmail())
        //        .Returns("john.doe@example.com");
        //    validateInputMock.SetupSequence(v => v.GetChoice(2))
        //        .Returns(1); // Choose Savings account type
        //    validateInputMock.SetupSequence(v => v.GetAmount("Enter your initial deposit: "))
        //        .Returns(1000);

        //    // Set up expectations for the mocked dependencies
        //    var expectedAccount = new AccountModel
        //    {
        //        OwnerFullName = "John Doe",
        //        AccountNumber = It.IsAny<string>(), // Account number will be generated randomly
        //        AccountType = "Savings",
        //        Balance = 1000,
        //        Password = "P@ssw0rd",
        //        Email = "john.doe@example.com",
        //    };

        //    printerMock.Setup(p => p.AccountDetails(It.IsAny<AccountModel>()));
        //    banksMock.Setup(b => b.AddAccount(It.IsAny<AccountModel>()));

        //    // Act
        //    userInput.CreateAccount();

        //    // Assert
        //    validateInputMock.Verify(v => v.GetFullName(), Times.Once);
        //    validateInputMock.Verify(v => v.GetPassword(), Times.Once);
        //    validateInputMock.Verify(v => v.GetEmail(), Times.Once);
        //    validateInputMock.Verify(v => v.GetChoice(2), Times.Once);
        //    validateInputMock.Verify(v => v.GetAmount("Enter your initial deposit: "), Times.Once);

        //    banksMock.Verify(b => b.AddAccount(It.Is<AccountModel>(a =>
        //        a.OwnerFullName == expectedAccount.OwnerFullName &&
        //        a.AccountType == expectedAccount.AccountType &&
        //        a.Balance == expectedAccount.Balance &&
        //        a.Password == expectedAccount.Password &&
        //        a.Email == expectedAccount.Email
        //    )), Times.Once);

        //    printerMock.Verify(p => p.AccountDetails(It.Is<AccountModel>(a =>
        //        a.OwnerFullName == expectedAccount.OwnerFullName &&
        //        a.AccountType == expectedAccount.AccountType &&
        //        a.Balance == expectedAccount.Balance &&
        //        a.Password == expectedAccount.Password &&
        //        a.Email == expectedAccount.Email
        //    )), Times.Once);
        //}
    }
}
