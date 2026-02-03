using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>();

        leaderboard.Add(55.42, "SwiftRacer");
        leaderboard.Add(52.10, "SpeedDemon");
        leaderboard.Add(58.91, "SteadyEddie");
        leaderboard.Add(51.05, "TurboTom");

        Console.WriteLine("---------Initial Leaderboard---------");
        foreach (var entry in leaderboard)
        {
            Console.WriteLine($"Time(s): {entry.Key}, Player Name: {entry.Value}");
        }

        var fastest = leaderboard.First();
        Console.WriteLine($"\nFastest Time: {fastest.Key}, Name: {fastest.Value}");

        leaderboard.Remove(58.91);
        Console.WriteLine("58.91 is removed successfully");

        leaderboard.Add(54.00, "SteadyEddie");

        Console.WriteLine("\n-----------Updated Leaderboard-----------");
        foreach (var entry in leaderboard)
        {
            Console.WriteLine($"Time(s): {entry.Key}, Player Name: {entry.Value}");
        }
    }
}
