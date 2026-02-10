namespace ADVLearning
{
    internal class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }

        public Loan(string clientName, double principal, double interestRate)
        {
            ClientName = clientName;
            Principal = principal;
            InterestRate = interestRate;
        }

        public double CalculateInterest()
        {
            return Principal * InterestRate / 100;
        }

        public string RiskLevel()
        {
            if (InterestRate > 10)
                return "High Risk";
            else if (InterestRate >= 5)
                return "Medium Risk";
            else
                return "Low Risk";
        }

        public override string ToString()
        {
            return $"{ClientName,-10} | {Principal,12:C} | {CalculateInterest(),10:C} | {RiskLevel()}";
        }
    }
}
