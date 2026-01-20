using System;

namespace WeeklySalesAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int DAYS = 7;
            decimal[] sales = new decimal[DAYS];
            string[] categories = new string[DAYS];

            // 1. Data Capture with Validation
            for (int i = 0; i < DAYS; i++)
            {
                while (true)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    bool isValid = decimal.TryParse(Console.ReadLine(), out sales[i]);

                    if (isValid && sales[i] >= 0)
                        break;

                    Console.WriteLine("Invalid input. Sales must be a non-negative number.");
                }
            }

            // 2. Weekly Sales Analysis
            decimal totalSales = 0;
            decimal highestSale = sales[0];
            decimal lowestSale = sales[0];
            int highestDay = 1;
            int lowestDay = 1;

            for (int i = 0; i < DAYS; i++)
            {
                totalSales += sales[i];

                if (sales[i] > highestSale)
                {
                    highestSale = sales[i];
                    highestDay = i + 1;
                }

                if (sales[i] < lowestSale)
                {
                    lowestSale = sales[i];
                    lowestDay = i + 1;
                }
            }

            decimal averageSales = totalSales / DAYS;

            int daysAboveAverage = 0;
            for (int i = 0; i < DAYS; i++)
            {
                if (sales[i] > averageSales)
                    daysAboveAverage++;
            }

            // 3. Sales Categorization (Parallel Array)
            for (int i = 0; i < DAYS; i++)
            {
                if (sales[i] < 5000)
                    categories[i] = "Low";
                else if (sales[i] <= 15000)
                    categories[i] = "Medium";
                else
                    categories[i] = "High";
            }

            // 4. Output Report
            Console.WriteLine("\nWeekly Sales Report");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Total Sales        : {totalSales:F2}");
            Console.WriteLine($"Average Daily Sale : {averageSales:F2}\n");

            Console.WriteLine($"Highest Sale       : {highestSale:F2} (Day {highestDay})");
            Console.WriteLine($"Lowest Sale        : {lowestSale:F2}  (Day {lowestDay})\n");

            Console.WriteLine($"Days Above Average : {daysAboveAverage}\n");

            Console.WriteLine("Day-wise Sales Category");
            for (int i = 0; i < DAYS; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}");
            }
        }
    }
}
