using System;
using System.Globalization;
using System.Collections.Generic;
using BankAccount.Entities;

namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();

            accounts.Add(new SavingsAccount(1001, "Giulia", 1000.00, 0.01));
            accounts.Add(new BusinessAccount(1002, "Maria", 1000.00, 500.00));

            double sum = 0.0;
            foreach (Account account in accounts)
            {
                sum += account.Balance;
            }

            Console.WriteLine("Total balance: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));

            foreach (Account account in accounts)
            {
                account.Withdraw(10.0);
            }

            Console.WriteLine();

            foreach (Account account in accounts)
            {
                Console.WriteLine("Updated balance for account "
                    + account.Number
                    + ": $ "
                    + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}