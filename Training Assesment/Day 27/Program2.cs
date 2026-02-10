using System;
using System.Collections.Generic;

namespace ADVLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            LoanDetails ld = new LoanDetails();

            Console.Write("Enter Client Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Principal Amount: ");
            double principal = double.Parse(Console.ReadLine());

            Console.Write("Enter Interest Rate: ");
            double interestRate = double.Parse(Console.ReadLine());

            Loan loan = new Loan(name, principal, interestRate);
            ld.AddLoan(loan);

            Console.WriteLine("\nCLIENT      |   PRINCIPAL   |  INTEREST  | RISK LEVEL");
            Console.WriteLine("-----------------------------------------------------");

            List<Loan> loans = ld.ReadLoan();
            foreach (Loan ln in loans)
            {
                Console.WriteLine(ln);
            }

            Console.ReadLine();
        }
    }
}
