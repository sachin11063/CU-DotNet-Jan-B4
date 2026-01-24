using System;

namespace SalesOrderProcessingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TOTAL_DAYS = 7;

            decimal[] dailyRevenue = new decimal[TOTAL_DAYS];
            string[] revenueLevel = new string[TOTAL_DAYS];

            InputSales(dailyRevenue);

            decimal sumRevenue = GetTotal(dailyRevenue);
            decimal avgRevenue = GetAverage(sumRevenue, TOTAL_DAYS);

            int maxDay, minDay;
            decimal maxSale = GetMaxSale(dailyRevenue, out maxDay);
            decimal minSale = GetMinSale(dailyRevenue, out minDay);

            bool festival = true;
            decimal discountAmount = GetDiscount(sumRevenue, festival);

            decimal taxAmount = GetTax(sumRevenue - discountAmount);
            decimal netAmount = GetNetAmount(sumRevenue, discountAmount, taxAmount);

            AssignCategory(dailyRevenue, revenueLevel);

            DisplaySummary(
                sumRevenue,
                avgRevenue,
                maxSale,
                maxDay,
                minSale,
                minDay,
                discountAmount,
                taxAmount,
                netAmount,
                revenueLevel
            );
        }

        static void InputSales(decimal[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal input) && input >= 0)
                    {
                        values[i] = input;
                        break;
                    }
                    Console.WriteLine("Invalid input. Enter a non-negative number.");
                }
            }
        }

        static decimal GetTotal(decimal[] values)
        {
            decimal sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum;
        }

        static decimal GetAverage(decimal total, int days)
        {
            return total / days;
        }

        static decimal GetMaxSale(decimal[] values, out int day)
        {
            decimal max = values[0];
            day = 1;

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                    day = i + 1;
                }
            }
            return max;
        }

        static decimal GetMinSale(decimal[] values, out int day)
        {
            decimal min = values[0];
            day = 1;

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] < min)
                {
                    min = values[i];
                    day = i + 1;
                }
            }
            return min;
        }

        static decimal GetDiscount(decimal total)
        {
            return total >= 50000 ? total * 0.10m : total * 0.05m;
        }

        static decimal GetDiscount(decimal total, bool isFestival)
        {
            decimal baseDiscount = GetDiscount(total);
            if (isFestival)
            {
                baseDiscount += total * 0.05m;
            }
            return baseDiscount;
        }

        static decimal GetTax(decimal amount)
        {
            return amount * 0.18m;
        }

        static decimal GetNetAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount + tax;
        }

        static void AssignCategory(decimal[] values, string[] labels)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < 5000)
                    labels[i] = "Low";
                else if (values[i] <= 15000)
                    labels[i] = "Medium";
                else
                    labels[i] = "High";
            }
        }

        static void DisplaySummary(
            decimal total,
            decimal average,
            decimal max,
            int maxDay,
            decimal min,
            int minDay,
            decimal discount,
            decimal tax,
            decimal net,
            string[] labels)
        {
            Console.WriteLine("\nWeekly Sales Summary");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total Sales        : {total:F2}");
            Console.WriteLine($"Average Daily Sale : {average:F2}\n");

            Console.WriteLine($"Highest Sale       : {max:F2} (Day {maxDay})");
            Console.WriteLine($"Lowest Sale        : {min:F2} (Day {minDay})\n");

            Console.WriteLine($"Discount Applied   : {discount:F2}");
            Console.WriteLine($"Tax Amount         : {tax:F2}");
            Console.WriteLine($"Final Payable      : {net:F2}\n");

            Console.WriteLine("Day-wise Category:");
            for (int i = 0; i < labels.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {labels[i]}");
            }
        }
    }
}
