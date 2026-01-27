using System;

namespace Day_16
{
    public static class ApplicationConfig
    {
        public static string ApplicationName { get; private set; }
        public static string Environment { get; private set; }
        public static int AccessCount { get; private set; }
        public static bool IsInitialized { get; private set; }

        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;

            Console.WriteLine("Static constructor executed");
        }

        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount++;
        }

        public static string GetConfigurationSummary()
        {
            AccessCount++;

            return $"Application Name: {ApplicationName}\n" +
                   $"Environment: {Environment}\n" +
                   $"Access Count: {AccessCount}\n" +
                   $"Is Initialized: {IsInitialized}";
        }

        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount++;
        }
    }

    internal class Demo
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ApplicationConfig.ApplicationName);

            ApplicationConfig.Initialize("LoanApp", "Production");

            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());

            ApplicationConfig.ResetConfiguration();

            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
        }
    }
}
