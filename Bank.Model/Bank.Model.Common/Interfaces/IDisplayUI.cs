using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Common.Interfaces
{
    public interface IDisplayUI
    {
        void Menu();
        void UserMenu();
        void AccountType();
        void AppMenu();
        void ExitMessages();
    }
}
