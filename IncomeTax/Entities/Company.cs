using System;

namespace IncomeTax.Entities
{
    internal class Company : TaxPayer
    {
        public int NumberOfEmployees { get; set; }

        public Company(string name, double annualIncome, int numberOfEmployees) : base(name, annualIncome)
        {
            NumberOfEmployees = numberOfEmployees;
        }

        public override double CalculationRule()
        {
            return (NumberOfEmployees > 10) ? (AnnualIncome * 0.14) : (AnnualIncome * 0.16);
        }
    }
}