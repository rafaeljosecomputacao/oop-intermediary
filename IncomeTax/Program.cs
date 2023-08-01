using System;
using System.Globalization;
using System.Collections.Generic;
using IncomeTax.Entities;

namespace IncomeTax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayers = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Annual income: ");
                double annualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxPayers.Add(new Individual(name, annualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    taxPayers.Add(new Company(name, annualIncome, numberOfEmployees));
                }
            }

            Console.WriteLine();
            Console.WriteLine("Taxes paid:");
            double taxes = 0.0;
            foreach (TaxPayer taxPayer in taxPayers)
            {
                Console.WriteLine(taxPayer.Name + ": $ " + taxPayer.CalculationRule().ToString("F2", CultureInfo.InvariantCulture));
                taxes += taxPayer.CalculationRule();
            }
            Console.WriteLine();
            Console.WriteLine("Total taxes: $ " + taxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}