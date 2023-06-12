using System;
using Bank.Model.Common.Implementations;
using Bank.Model.Common.Models;
using Bank.Model.Common.Interfaces;
using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Model
{

    public class Program
    {
        public static void Main()
        {

            var services = new ServiceCollection();
            ConfigureServices(services);
            //services
            //    .AddSingleton<IBank, Banks>()
            //    .BuildServiceProvider()
            //    .GetService<Banks>()
            //    .Start();

            //var serviceProvider = services.BuildServiceProvider();
            //var bank = serviceProvider.GetService<IBank>();
            //bank.Start();

            services
                .BuildServiceProvider()
                .GetService<IBank>()
                .Start();

            //.AddTransient<IDisplayUI, DisplayUI>()
        }

        //public static void ConfigureServices(ServiceCollection services)
        //{
        //    services.AddTransient<IPrinter, Printer>();
        //    services.AddTransient<IValidateInput, ConsoleUserInput>();
        //    services.AddTransient<IDisplayUI, DisplayUI>();
        //    services.AddTransient<IAccount, Account>();
        //}


        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPrinter, Printer>();
            services.AddScoped<IValidateInput, ConsoleUserInput>();
            services.AddScoped<IDisplayUI, DisplayUI>();
            services.AddScoped<IAccount, Account>();
            services.AddSingleton<IBank>(provider =>
            {
                //var filePath = "accounts.json"; // Replace with the actual file path
                //var filePath = "accounts.txt"; // Replace with the actual file path
                var filePath = "accounts.csv"; // Replace with the actual file path
                var printer = provider.GetRequiredService<IPrinter>();
                var validateInput = provider.GetRequiredService<IValidateInput>();
                var displayUI = provider.GetRequiredService<IDisplayUI>();
                var account = provider.GetRequiredService<IAccount>();
                return new Banks(filePath, printer, validateInput, displayUI, account);
            });
        }


        //public static void ConfigureServices(ServiceCollection services)
        //{
        //    services.AddScoped<IPrinter, Printer>();
        //    services.AddScoped<IValidateInput, ConsoleUserInput>();
        //    services.AddScoped<IDisplayUI, DisplayUI>();
        //    //services.AddTransient<IBank, Banks>(); // Register the Banks class itself as the implementation for IBank
        //    services.AddScoped<IAccount, Account>();
        //    services.AddSingleton<IBank, Banks>();

        //}


    }
}
