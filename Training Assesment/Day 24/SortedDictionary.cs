using System.Xml.Schema;

namespace Leaderboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>();
            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");

            foreach (var entry in leaderboard)
            {
                Console.WriteLine($"Time(s): {entry.Key}, Player Name: {entry.Value}");
            }

            var Fastest = leaderboard.First();
            System.Console.WriteLine($"Fastest Time: {Fastest.Key}, Name: {Fastest.Value}");

            double val = 58.91;
            leaderboard.Remove(val);
            System.Console.WriteLine($"{val} is Removed Sucessfully");
            leaderboard.Add(54.00, "SteadyEddie");
            System.Console.WriteLine("\nUpdated Leaderboard:");

            foreach (var entry in leaderboard)
            {
                Console.WriteLine($"Time(s): {entry.Key}, Player Name: {entry.Value}");
            }
        }
    }
}