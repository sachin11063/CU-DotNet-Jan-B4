
namespace CSLearning
{
	internal class DataType
    {	
			static void Main(string[] args)
            {
            
            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums = new decimal[5];

            decimal max = decimal.MinValue;
            decimal min = decimal.MaxValue;
            decimal total = 0;

            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    Console.Write($"Enter Name of Policy Holder {i + 1}: ");
                    policyHolderNames[i] = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(policyHolderNames[i]))
                    {
                        break;
                    }
                    Console.WriteLine("Place Holder Name Can not be Empty. Please enter again.");
                }

                while (true) { 
                    Console.Write($"Enter Annual Premium of Insurence Holder {i + 1}: ");
                    annualPremiums[i] = decimal.Parse(Console.ReadLine());

                    if (annualPremiums[i] > 0)
                    {
                        break;
                    }

                    Console.WriteLine("Annual Premium must be greater than 0. Please enter again.");
                }

                total += annualPremiums[i];
            }

            decimal avg = total / 5;
            max = annualPremiums.Max();
            min = annualPremiums.Min();


            Console.WriteLine("Insurence Policy Summary:");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("{0,-15} {1,-15} {2,-15}", "Name", "Premium", "Category");
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < 5; i++)
            {
                if (annualPremiums[i] < 10000) {
                    Console.WriteLine("{0,-15} {1,-15:F2} {2,-15}", policyHolderNames[i].ToUpper(), min, "LOW");
                }
                if (annualPremiums[i] >= 10000 && annualPremiums[i] <= 25000)
                {
                    Console.WriteLine("{0,-15} {1,-15:F2} {2,-15}", policyHolderNames[i].ToUpper(), avg, "MEDIUM");
                }
                if (annualPremiums[i] > 25000)
                {
                    Console.WriteLine("{0,-15} {1,-15:F2} {2,-15}", policyHolderNames[i].ToUpper(), max, "HIGH");
                }
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"{"Total Premium",-20}: ₹ {total:N2}");
            Console.WriteLine($"{"Average Premium",-20}: ₹ {avg:N2}");
            Console.WriteLine($"{"Highest Premium",-20}: ₹ {max:N2}");
            Console.WriteLine($"{"Lowest Premium",-20}: ₹ {min:N2}");



        }

    }
}

