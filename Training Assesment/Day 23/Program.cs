using System;

namespace StudentEnrollmentSystem
{
    class InvalidStudentAgeException : Exception
    {
        public InvalidStudentAgeException(string message) : base(message)
        {
        }

        public InvalidStudentAgeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException(string message) : base(message)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter first integer:");
                int a = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter second integer:");
                int b = int.Parse(Console.ReadLine());

                int result = a / b;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            finally
            {
                Console.WriteLine("Operation Completed\n");
            }

            try
            {
                Console.WriteLine("Enter a number:");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("You entered: " + number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format.");
            }
            finally
            {
                Console.WriteLine("Operation Completed\n");
            }

            try
            {
                int[] arr = new int[5];
                Console.WriteLine(arr[10]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Index out of range.");
            }
            finally
            {
                Console.WriteLine("Operation Completed\n");
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter student name:");
                    string name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                        throw new InvalidStudentNameException("Student name cannot be empty.");

                    Console.WriteLine("Enter student age:");
                    int age;

                    try
                    {
                        age = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        throw new InvalidStudentAgeException("Age must be a valid number.", ex);
                    }

                    if (age < 18 || age > 60)
                        throw new InvalidStudentAgeException("Student age must be between 18 and 60.");

                    Console.WriteLine("Student details accepted successfully.");
                    break;
                }
                catch (InvalidStudentNameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidStudentAgeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException?.Message ?? "No Inner Exception");
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    Console.WriteLine("Operation Completed\n");
                }
            }
        }
    }
}
