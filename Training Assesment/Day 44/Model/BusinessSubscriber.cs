using System;

namespace SaaSArchitect.Models
{
    public class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public BusinessSubscriber(Guid id, string name, DateTime joinDate,
            decimal fixedRate, decimal taxRate)
            : base(id, name, joinDate)
        {
            FixedRate = fixedRate;
            TaxRate = taxRate;
        }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }
}