using System;

namespace Bank.Model.Common.Models
{
    public class TransactionModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }

    }
}
