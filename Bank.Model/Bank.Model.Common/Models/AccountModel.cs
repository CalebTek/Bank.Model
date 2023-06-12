using System.Collections.Generic;

namespace Bank.Model.Common.Models
{
    public class AccountModel
    {
        public string OwnerFullName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<TransactionModel> Transactions { get; set; }
        public decimal Balance { get; set; }

        public AccountModel()
        {
            Transactions = new List<TransactionModel>();
        }
    }
}
