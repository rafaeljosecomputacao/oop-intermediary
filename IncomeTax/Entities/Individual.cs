using System;

namespace IncomeTax.Entities
{
    internal class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public Individual(string name, double annualIncome, double healthExpenditures) : base(name, annualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double CalculationRule()
        {
            double tax = 0.0;
            if (HealthExpenditures > 0)
            {
                tax = (AnnualIncome < 20000.0) ? ((AnnualIncome * 0.15) - (HealthExpenditures * 0.5)) : ((AnnualIncome * 0.25) - (HealthExpenditures * 0.5));
            }
            else
            {
                tax = (AnnualIncome < 20000.0) ? (AnnualIncome * 0.15) : (AnnualIncome * 0.25);
            }
            return tax;
        }
    }
}