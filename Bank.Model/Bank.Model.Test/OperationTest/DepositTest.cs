using Xunit;
using Moq;
using Bank.Model.Common.Interfaces;
using Bank.Model.Common.Models;
using Bank.Model.Common.Implementations;

namespace Bank.Model.Tests
{
    public class DepositTests
    {
        //[Fact]
        //public void Deposit_ValidAmount_SuccessfulDeposit()
        //{
        //    // Arrange
        //    var validateInputMock = new Mock<IValidateInput>();
        //    var accountMock = new Mock<IAccount>();
        //    var printerMock = new Mock<IPrinter>();
        //    var bankMock = new Mock<IBank>();
        //    var displayMock = new Mock<IDisplayUI>();



        //    validateInputMock.Setup(v => v.GetAmount("Enter the deposit amount: "))
        //        .Returns(100);

        //    var accountModel = new AccountModel
        //    {
        //        Balance = 500
        //    };

        //    var sut = new Account();//printerMock.Object, validateInputMock.Object, bankMock.Object, displayMock.Object, accountMock.Object);

        //    // Act
        //    sut.Deposit(accountModel);

        //    // Assert
        //    Assert.Equal(600, accountModel.Balance);
        //    //accountMock.Verify(a => a.Transactions.Add(It.IsAny<TransactionModel>()), Times.Once);
        //    // Additional assertions for the transaction details
        //}
    }
}
