using Xunit;
using Moq;
using Bank.Model.Common.Interfaces;
using Bank.Model.Common.Models;
using Bank.Model.Common.Implementations;

namespace Bank.Model.Test.OperationTest
{
    public class LoginTests
    {
        //[Fact]
        //public void Login_ValidCredentials_SuccessfulLogin()
        //{
        //    // Arrange
        //    var validateInputMock = new Mock<IValidateInput>();
        //    var bankMock = new Mock<IBank>();
        //    var accountMock = new Mock<IAccount>();
        //    var printerMock = new Mock<IPrinter>();
        //    var displayMock = new Mock<IDisplayUI>();

        //    validateInputMock.Setup(v => v.GetAccountNumber())
        //        .Returns("1234567890");

        //    validateInputMock.Setup(v => v.GetPassword())
        //        .Returns("Test123!");

        //    var accountModel = new AccountModel
        //    {
        //        AccountNumber = "1234567890",
        //        Password = "Test123!",
        //        OwnerFullName = "John Doe"
        //    };

        //    bankMock.Setup(b => b.GetAccounts())
        //        .Returns(new List<AccountModel> { accountModel });

        //    printerMock.Setup(p => p.Print("Welcome, John Doe!"));
        //    displayMock.Setup(p => p.UserMenu());
        //    printerMock.Setup(p => p.Statement(It.IsAny<AccountModel>()));
        //    printerMock.Setup(p => p.Balance(It.IsAny<AccountModel>()));

        //    accountMock.Setup(a => a.Deposit(It.IsAny<AccountModel>()));
        //    accountMock.Setup(a => a.Withdraw(It.IsAny<AccountModel>()));
        //    accountMock.Setup(a => a.Transfer(It.IsAny<IBank>(), It.IsAny<AccountModel>()));
        //    bankMock.Setup(a => a.CreateAccount());

        //    //var sut = new Banks();

        //    var sut = new Banks(printerMock.Object, validateInputMock.Object, bankMock.Object, displayMock.Object, accountMock.Object);
        //    //         public Banks(IPrinter printer, IValidateInput validateInput, IBank bank, IDisplayUI displayUI, IAccount account)
        //    // Act
        //    sut.Login();

        //    // Act
        //    //sut.Login(validateInputMock.Object, bankMock.Object, accountMock.Object, printerMock.Object);

        //    // Assert
        //    // Verify the expected interactions with the mocks
        //    validateInputMock.Verify(v => v.GetAccountNumber(), Times.Once);
        //    validateInputMock.Verify(v => v.GetPassword(), Times.Once);
        //    bankMock.Verify(b => b.GetAccounts(), Times.Once);
        //    printerMock.Verify(p => p.Print("Welcome, John Doe!"), Times.Once);
        //    displayMock.Verify(p => p.UserMenu(), Times.Once);
        //    printerMock.Verify(p => p.Statement(It.IsAny<AccountModel>()), Times.Exactly(2)); // Depending on the flow, you may need to adjust this
        //    printerMock.Verify(p => p.Balance(It.IsAny<AccountModel>()), Times.Once);
        //    accountMock.Verify(a => a.Deposit(It.IsAny<AccountModel>()), Times.Once);
        //    accountMock.Verify(a => a.Withdraw(It.IsAny<AccountModel>()), Times.Once);
        //    accountMock.Verify(a => a.Transfer(It.IsAny<IBank>(), It.IsAny<AccountModel>()), Times.Once);
        //    bankMock.Verify(a => a.CreateAccount(), Times.Once);
        //}
    }
}
