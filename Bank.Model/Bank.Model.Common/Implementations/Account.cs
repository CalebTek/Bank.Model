using Bank.Model.Common.Interfaces;
using Bank.Model.Common.Models;
using Microsoft.VisualStudio.Services.Account;
using System;
using System.Security.Principal;

namespace Bank.Model.Common.Implementations
{
    public class Account : IAccount
    {
        private IValidateInput _Validate;

        public Account(IValidateInput validateInput)
        {
            _Validate = validateInput;
        }

    }
}