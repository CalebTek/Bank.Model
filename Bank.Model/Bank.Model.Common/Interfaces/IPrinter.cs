using Bank.Model.Common.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Common.Interfaces
{
    public interface IPrinter
    {
        void Statement(AccountModel account);

        void Balance(AccountModel account);

        void AccountDetails(AccountModel account);
        void Print(string v);
    }
}
