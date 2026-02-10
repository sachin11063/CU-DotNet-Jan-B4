using System.Collections.Generic;
using System.IO;

namespace ADVLearning
{
    class LoanDetails
    {
        private string FilePath = "loan.txt";

        public void AddLoan(Loan loan)
        {
            using (StreamWriter sw = new StreamWriter(FilePath, true))
            {
                sw.WriteLine($"{loan.ClientName},{loan.Principal},{loan.InterestRate}");
            }
        }

        public List<Loan> ReadLoan()
        {
            List<Loan> loans = new List<Loan>();

            if (!File.Exists(FilePath))
                return loans;

            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length != 3)
                        continue;

                    if (double.TryParse(parts[1], out double principal) &&
                        double.TryParse(parts[2], out double rate))
                    {
                        loans.Add(new Loan(parts[0], principal, rate));
                    }
                }
            }
            return loans;
        }
    }
}
