using Bank.Model.Common.Interfaces;
using Bank.Model.Common.Models;
using Microsoft.VisualStudio.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.TeamFoundation.Common.Internal.NativeMethods;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using static Microsoft.VisualStudio.Services.Graph.Constants;
using System.Security.Principal;

namespace Bank.Model.Common.Implementations
{
    public class Banks : IBank
    {
        [FileExtensions(Extensions = ".json,.csv,.txt")]
        private string filePath; // Path to the file
        private List<AccountModel> accounts;
        private IDisplayUI _UI;
        private IPrinter _Print;
        //private IBank _bank; // null
        private IValidateInput _Validate;
        private IAccount _account;

        //public Banks(IPrinter printer, IValidateInput validateInput, IBank bank, IDisplayUI displayUI, IAccount account)
        //{
        //    accounts = new List<AccountModel>();
        //    _Print = printer;
        //    _Validate = validateInput;
        //    _account = account;
        //    _UI = displayUI;
        //    _bank = bank;

        //}
        public Banks(string filePath, IPrinter printer, IValidateInput validateInput, IDisplayUI displayUI, IAccount account)//, IBank bank)
        {
            accounts = new List<AccountModel>();
            _Print = printer;
            _Validate = validateInput;
            _UI = displayUI;
            _account = account;
            //_bank = bank;
            //_Print = new Printer();
            //_Validate = new ConsoleUserInput();
            //_UI = new DisplayUI();
            //_account = new Account();

            this.filePath = filePath;

            // Load accounts from the file (if it exists)
            if (File.Exists(filePath))
            {
                LoadAccountsFromFile();
            }
        }


        public List<AccountModel> GetAccounts()
        {
            return accounts;
        }

        public void AddAccount(AccountModel account)
        {
            accounts.Add(account);
        }

        private void LoadAccountsFromFile()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] accountData = line.Split(',');

                        if (accountData.Length >= 6)
                        {
                            AccountModel account = new AccountModel()
                            {
                                OwnerFullName = accountData[0],
                                AccountNumber = accountData[1],
                                AccountType = accountData[2],
                                Password = accountData[3],
                                Email = accountData[4],
                                Balance = decimal.Parse(accountData[5])
                            };

                            for (int i = 6; i < accountData.Length; i += 4)
                            {
                                DateTime transactionDate;
                                if (DateTime.TryParse(accountData[i], out transactionDate))
                                {
                                    TransactionModel transaction = new TransactionModel()
                                    {
                                        Date = transactionDate,
                                        Description = accountData[i + 1],
                                        Amount = decimal.Parse(accountData[i + 2]),
                                        Balance = decimal.Parse(accountData[i + 3])
                                    };

                                    account.Transactions.Add(transaction);
                                }
                            }

                            accounts.Add(account);
                        }
                    }

                    Console.WriteLine("Accounts loaded from file.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading accounts from file: {ex.Message}");
                }
            }
        }

        //private void LoadAccountsFromFile()
        //{
        //    // Read the contents of the file
        //    string json = File.ReadAllText(filePath);

        //    // Deserialize JSON into a list of AccountModel objects
        //    accounts = JsonConvert.DeserializeObject<List<AccountModel>>(json);
        //}

        private void SaveAccountsToFile()
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (AccountModel account in accounts)
                {
                    string line = $"{account.OwnerFullName},{account.AccountNumber},{account.AccountType},{account.Password},{account.Email},{account.Balance}";

                    foreach (TransactionModel transaction in account.Transactions)
                    {
                        line += $",{transaction.Date},{transaction.Description},{transaction.Amount},{transaction.Balance}";
                    }

                    lines.Add(line);
                }

                File.WriteAllLines(filePath, lines);

                Console.WriteLine("Accounts saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving accounts to file: {ex.Message}");
            }
        }

        //private void SaveAccountsToFile()
        //{
        //    // Serialize the accounts list to JSON
        //    string json = JsonConvert.SerializeObject(accounts);

        //    // Write the JSON to the file
        //    File.WriteAllText(filePath, json);
        //}


        public void Start()
        {
            //filePath = "accounts.json";
            //filePath = "accounts.txt";
            //filePath = "accounts.csv";

            Console.WriteLine("Please wait while processing...");
            Thread.Sleep(3000);
            Console.Clear();

            _UI.AppMenu();

            int choice;
            do
            {
                _UI.Menu();

                choice = _Validate.GetChoice(3);

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        //CreateAccount();
                        // Create a new thread for the CreateAccount method
                        Thread createAccountThread = new Thread(CreateAccount);
                        createAccountThread.Start();
                        createAccountThread.Join();
                        break;
                    case 2:
                        Console.Clear();
                        //Login();
                        // Create a new thread for the Login method
                        Thread loginThread = new Thread(Login);
                        loginThread.Start();
                        loginThread.Join();
                        break;
                    case 3:
                        _UI.ExitMessages();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 3);
        }
        public void CreateAccount()
        {
            //Console.Clear();
            Console.WriteLine("Please wait while processing...");
            Thread.Sleep(3000);

            Console.Clear();

            Console.WriteLine("CREATE ACCOUNT\n");

            string fullName = _Validate.GetFullName();

            string password = _Validate.GetPassword();

            string email = _Validate.GetEmail();

            // Create account in a separate thread
            Thread createAccountThread = new Thread(() =>
            {

                // Generate a random account number
                Random random = new Random();
            string accountNumber = random.Next(1000000000, 2000000000).ToString();

            _UI.AccountType();
            int choice = _Validate.GetChoice(2);
            string accountType = "";
            switch (choice)
            {
                case 1:
                    accountType = "Savings";
                    break;
                case 2:
                    accountType = "Current";
                    break;

            }

            decimal balance = _Validate.GetAmount("Enter your initial deposit: ");



                AccountModel account = new AccountModel
                {
                    OwnerFullName = fullName,
                    AccountNumber = accountNumber,
                    AccountType = accountType,
                    Balance = balance,
                    Password = password,
                    Email = email,
                };

                AddAccount(account);

                Thread.Sleep(5000);

                Console.WriteLine("Account created successfully!");
                // Add the transfer transaction to the sender's transaction history
                account.Transactions.Add(new TransactionModel
                {
                    Date = DateTime.Now,
                    Description = $"Initial Deposit",
                    Amount = balance,
                    Balance = account.Balance
                });


                // Display the created account details
                Console.Clear();
                _Print.AccountDetails(account);

                // Save the updated accounts to the file
                SaveAccountsToFile();
            });
            createAccountThread.Start();
            createAccountThread.Join();

        }

        public void Login()
        {
            Console.WriteLine("Please wait while processing...");
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("LOGIN\n");
            string accountNumber = _Validate.GetAccountNumber();
            string password = _Validate.GetPassword();

            AccountModel account = GetAccounts().Find(a => a.AccountNumber == accountNumber && a.Password == password);

            if (account != null)
            {
                Console.Clear();
                Console.WriteLine("Please wait while processing...");
                Thread.Sleep(5000);
                Console.Clear();

                Thread userMenuThread = new Thread(() =>
                {
                    Console.WriteLine($"Welcome, {account.OwnerFullName} ({account.AccountNumber})!");

                    int choice;
                    do
                    {
                        _UI.UserMenu();

                        choice = _Validate.GetChoice(7);

                        switch (choice)
                        {
                            case 1:
                                Thread depositThread = new Thread(() =>
                                {
                                    Console.Clear();
                                    Deposit(account);
                                });
                                depositThread.Start();
                                depositThread.Join();
                                break;
                            case 2:
                                Thread withdrawThread = new Thread(() =>
                                {
                                    Console.Clear();
                                    Withdraw(account);
                                });
                                withdrawThread.Start();
                                withdrawThread.Join();
                                break;
                            case 3:
                                Thread transferThread = new Thread(() =>
                                {
                                    Console.Clear();
                                    Transfer(account);
                                });
                                transferThread.Start();
                                transferThread.Join();
                                break;
                            case 4:
                                Console.Clear();
                                _Print.Statement(account);
                                break;
                            case 5:
                                Console.Clear();
                                _Print.Balance(account);
                                break;
                            case 6:
                                Console.Clear();
                                CreateAccount();
                                break;
                            case 7:
                                Console.WriteLine("Exiting...");
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                Console.Clear();
                                break;
                        }

                        Console.WriteLine();
                    } while (choice != 7);
                });

                userMenuThread.Start();
                userMenuThread.Join();
            }
            else
            {
                Console.WriteLine("Invalid account number or password. Please try again.");
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Deposit(AccountModel account)
        {

            Console.WriteLine("Please wait while processing...");
            Thread.Sleep(3000);

            Console.Clear();
            // Deposit in a separate thread
            Thread depositThread = new Thread(() =>
            {
                Console.WriteLine("DEPOSIT\n");

            decimal amount = _Validate.GetAmount("Enter the deposit amount: ");

            account.Balance += amount;

            // Add the deposit transaction to the account's transaction history
            account.Transactions.Add(new TransactionModel
            {
                Date = DateTime.Now,
                Description = "Deposit",
                Amount = amount,
                Balance = account.Balance
            });

                Console.WriteLine("Please wait while processing...");
                Thread.Sleep(5000);

                Console.Clear();
                Console.WriteLine("Deposit successful!");

            // Save the updated accounts to the file
            SaveAccountsToFile();
            });
            depositThread.Start();
            depositThread.Join();
        }

        public void Transfer(AccountModel senderAccount)
        {

            Console.WriteLine("Please wait while processing...");
            Thread.Sleep(3000);

            Console.Clear();

            Console.WriteLine("TRANSFER\n");

            Console.WriteLine("Recipient's: ");
            string recipientAccountNumber = _Validate.GetAccountNumber();

            // Transfer in a separate thread
            Thread transferThread = new Thread(() =>
            {
                AccountModel recipientAccount = GetAccounts().Find(a => a.AccountNumber == recipientAccountNumber);

                if (recipientAccount == null)
                {
                    Console.WriteLine("Recipient account not found.");
                }
                else
                {
                    decimal amount = _Validate.GetAmount("Enter the transfer amount: ");

                    if (amount > senderAccount.Balance)
                    {
                        Console.WriteLine("Insufficient balance.");
                    }
                    else if (senderAccount.AccountType == "Savings" && amount > senderAccount.Balance - 1000)
                    {
                        Console.WriteLine("Insufficient balance.");
                    }
                    else
                    {
                        senderAccount.Balance -= amount;
                        recipientAccount.Balance += amount;

                        // Add the transfer transaction to the sender's transaction history
                        senderAccount.Transactions.Add(new TransactionModel
                        {
                            Date = DateTime.Now,
                            Description = $"Transfer to Account {recipientAccountNumber}",
                            Amount = amount,
                            Balance = senderAccount.Balance
                        });

                        // Add the transfer transaction to the recipient's transaction history
                        recipientAccount.Transactions.Add(new TransactionModel
                        {
                            Date = DateTime.Now,
                            Description = $"Transfer from Account {senderAccount.AccountNumber}",
                            Amount = amount,
                            Balance = recipientAccount.Balance
                        });

                        Console.WriteLine("Please wait while processing...");
                        Thread.Sleep(5000);
                        Console.Clear();

                        Console.WriteLine("Transfer successful!");

                        // Save the updated accounts to the file
                        SaveAccountsToFile();
                    }
                }

            });
            transferThread.Start();
            transferThread.Join();

        }

        public void Withdraw(AccountModel account)
        {
            Console.WriteLine("Please wait while processing...");
            Thread.Sleep(3000);

            Console.Clear();

            Console.WriteLine("WITHDRAW\n");

            decimal amount = _Validate.GetAmount("Enter the withdrawal amount: ");

            if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else if (account.AccountType == "Savings" && amount > account.Balance-1000)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {

                // Withdraw in a separate thread
                Thread withdrawThread = new Thread(() =>
                {
                    account.Balance -= amount;

                    // Add the withdrawal transaction to the account's transaction history
                    account.Transactions.Add(new TransactionModel
                    {
                        Date = DateTime.Now,
                        Description = "Withdrawal",
                        Amount = amount,
                        Balance = account.Balance
                    });

                    Console.WriteLine("Please wait while processing...");
                    Thread.Sleep(5000);
                    Console.Clear();

                    Console.WriteLine("Withdrawal successful!");

                    // Save the updated accounts to the file
                    SaveAccountsToFile();
                });
                withdrawThread.Start();
                withdrawThread.Join();
                
            }
        }


    }
}
