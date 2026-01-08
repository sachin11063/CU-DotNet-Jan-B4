namespace ConsoleLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exercise 1: Student Attendance & Eligibility System
            int totalClasses = 90;
            int attendedClasses = 72;
            double attendancePercentage = (attendedClasses * 100.0) / totalClasses;
            int displayAttendance = (int)Math.Round(attendancePercentage);
            Console.WriteLine($"Attendance: {displayAttendance}%");

            // Exercise 2: Online Examination Result Processing
            int sub1 = 78, sub2 = 85, sub3 = 90;
            double averageMarks = (sub1 + sub2 + sub3) / 3.0;
            double formattedAverage = Math.Round(averageMarks, 2);
            int scholarshipAverage = (int)Math.Floor(formattedAverage);
            Console.WriteLine($"Average Marks: {formattedAverage}, Scholarship Score: {scholarshipAverage}");

            // Exercise 3: Library Fine Calculation System
            decimal finePerDay = 2.50m;
            int overdueDays = 4;
            decimal totalFine = finePerDay * overdueDays;
            double analyticsFine = (double)totalFine;
            Console.WriteLine($"Library Fine: {totalFine}");

            // Exercise 4: Banking Interest Calculation Module
            decimal accountBalance = 10000m;
            float interestRate = 7.5f;
            decimal interestAmount = accountBalance * ((decimal)interestRate / 100);
            accountBalance += interestAmount;
            Console.WriteLine($"Updated Balance: {accountBalance}");

            // Exercise 5: E-Commerce Order Pricing Engine
            double cartTotal = 1999.99;
            decimal taxRate = 0.18m;
            decimal finalPayable = (decimal)cartTotal * (1 + taxRate);
            Console.WriteLine($"Final Payable Amount: {finalPayable}");

            // Exercise 6: Weather Monitoring & Reporting
            short sensorReading = 320;
            double temperatureCelsius = sensorReading / 10.0;
            int displayTemperature = (int)Math.Round(temperatureCelsius);
            Console.WriteLine($"Temperature: {displayTemperature}°C");

            // Exercise 7: University Grading Engine
            double finalScore = 82.5;
            byte grade;

            if (finalScore >= 90)
                grade = 10;
            else if (finalScore >= 80)
                grade = 9;
            else if (finalScore >= 70)
                grade = 8;
            else
                grade = 5;

            Console.WriteLine($"Grade Point: {grade}");

            // Exercise 8: Mobile Data Usage Tracker
            long dataUsedBytes = 5368709120;
            double dataUsedGB = dataUsedBytes / (1024.0 * 1024 * 1024);
            int roundedDataUsage = (int)Math.Round(dataUsedGB);
            Console.WriteLine($"Data Used: {roundedDataUsage} GB");

            // Exercise 9: Warehouse Inventory Capacity Control
            int currentStock = 500;
            ushort maxCapacity = 600;
            bool isCapacityReached = currentStock >= maxCapacity;
            Console.WriteLine($"Capacity Reached: {isCapacityReached}");

            // Exercise 10: Payroll Salary Computation
            int basicSalary = 30000;
            double allowances = 4500.75;
            double deductions = 1200.25;
            decimal netSalary = basicSalary + (decimal)allowances - (decimal)deductions;
            Console.WriteLine($"Net Salary: {netSalary}");
        }
    }

}

