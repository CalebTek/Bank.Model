using Bank.Model.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Common.Implementations
{
    public class DisplayUI : IDisplayUI
    {
        private readonly string startMessage = $"MAIN MENU\n1. Create Account\n2. Login\n3. Exit";
        private readonly string userMessage = $"USER MENU\n1. Deposit\n2. Withdraw\n" +
            $"3. Transfer\n4. Print Statement\n5. Display Balance\n6. Set Up Another Account\n" +
            $"7. Exit";
        private readonly string AccountMessage = $"1. Savings\n2. Current";
        private readonly  string AppMessage = $"We are delighted to welcome you to our bank!\n" +
            $"We are committed to providing you with the best banking experience possible and\n" +
            $"We look forward to serving you.\n";
        private readonly  string ExitMessage = $"Thank you for choosing our bank.\n" +
            $"We appreciate your business and\n" +
            $"We hope to build a long-lasting relationship with you.";

        public void Menu()
        {
            Console.WriteLine(startMessage);
        }

        public void UserMenu() 
        {
            Console.WriteLine(userMessage);
        }

        public void AccountType()
        {
            Console.WriteLine(AccountMessage);
        }

        public void AppMenu()
        {
            Console.WriteLine(AppMessage);
        }

        public void ExitMessages()
        {
            Console.WriteLine(ExitMessage);
        }
    }
}
