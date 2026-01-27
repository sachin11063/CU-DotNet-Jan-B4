namespace Day_17;

public class Loan
{
    public string LoanNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal PrincipalAmount { get; set; }
    public int TenureInYear { get; set; }

    public Loan(string loanNumber, string customerName, decimal principalAmount, int tenureInYear)
    {
        LoanNumber = loanNumber;
        CustomerName = customerName;
        PrincipalAmount = principalAmount;
        TenureInYear = tenureInYear;
    }

    public decimal CalculateEMI()
    {
        return PrincipalAmount + (PrincipalAmount * 0.10m);
    }
}


public class HomeLoan : Loan
{
    public HomeLoan(string loanNumber, string customerName,
                    decimal principalAmount, int tenureInYear)
        : base(loanNumber, customerName, principalAmount, tenureInYear)
    {
    }
    public decimal CalculateEMI()
    {
        return PrincipalAmount + (TenureInYear * (PrincipalAmount * 0.08m)) + (PrincipalAmount * 0.01m);
    }
}

public class CarLoan : Loan
{
    public CarLoan(string loanNumber, string customerName,
                   decimal principalAmount, int tenureInYear)
        : base(loanNumber, customerName, principalAmount, tenureInYear)
    {
    }

    public decimal CalculateEMI()
    {
        return PrincipalAmount + (TenureInYear * (PrincipalAmount * 0.09m)) + 15000;
    }
}


internal class Demo
{
    public static void Main(string[] args)
    {
        Loan[] loans =
        {
            new HomeLoan("HL101", "Sachin", 1200000, 5),
            new HomeLoan("HL102", "Amit", 1500000, 10),
            new CarLoan("CL101", "Rahul", 500000, 6),
            new CarLoan("CL102", "Neha", 600000, 7)
        };

        foreach (Loan loan in loans)
        {
            Console.WriteLine($"Loan No: {loan.LoanNumber}, Customer Name: {loan.CustomerName}, EMI: {loan.CalculateEMI()}");
        }
    }
}


