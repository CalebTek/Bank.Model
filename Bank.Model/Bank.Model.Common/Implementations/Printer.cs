using Bank.Model.Common;
using Bank.Model.Common.Interfaces;
using Bank.Model.Common.Models;
using System;
using System.Globalization;

namespace Bank.Model.Common.Implementations
{
    public class Printer : IPrinter
    {

        public void Statement(AccountModel account)
        {
            //Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ACCOUNT STATEMENT ON ACCOUNT NO {account.AccountNumber}\n");
            Console.WriteLine("|---------------------|-----------------------------------------------|--------------------------|---------------------|");
            Console.WriteLine("| DATE                | DESCRIPTION                                   | AMOUNT                   | BALANCE             |");
            Console.WriteLine("|---------------------|-----------------------------------------------|--------------------------|---------------------|");

            foreach (TransactionModel transaction in account.Transactions)
            {
                Console.WriteLine($"| {transaction.Date, -10} | {transaction.Description,-45} | {transaction.Amount.ToString("C", new CultureInfo("ha-Latn-NG")), -24} | {transaction.Balance.ToString("C", new CultureInfo("ha-Latn-NG")), -19} |");
            }

            Console.WriteLine("|----------------------------------------------------------------------------------------------------------------------|");
            Console.ResetColor();
        }

        public void Balance(AccountModel account)
        {
            //Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ACCOUNT DETAILS\n");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine("| FULL NAME         | ACCOUNT NUMBER                | ACCOUNT TYPE             | AMOUNT BAL          |");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine($"| {account.OwnerFullName,-17} | {account.AccountNumber,-29} | {account.AccountType,-24} | {account.Balance.ToString("C", new CultureInfo("ha-Latn-NG")),-19} |");
            Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
            Console.ResetColor();
        }

        public void AccountDetails(AccountModel account)
        {
            //Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ACCOUNT DETAILS\n");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine("| FULL NAME         | ACCOUNT NUMBER                | ACCOUNT TYPE             | AMOUNT BAL          |");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine($"| {account.OwnerFullName,-17} | {account.AccountNumber,-29} | {account.AccountType,-24} | {account.Balance.ToString("C", new CultureInfo("ha-Latn-NG")),-19} |");
            Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
            Console.ResetColor();
        }

        public void Print(string v)
        {
            Console.WriteLine(v);
        }
    }
}
