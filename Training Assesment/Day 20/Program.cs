using System;
using System.Collections.Generic;
using Day_20;

namespace Day_20
{
    class Flight : IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime DepartureTime { get;set; }

        public Flight(string FlightNumber, decimal Price, TimeSpan Duration, DateTime DepartureTime)
        {
            this.FlightNumber = FlightNumber;
            this.Price = Price;
            this.Duration = Duration;
            this.DepartureTime = DepartureTime;
        }

        public int CompareTo(Flight? other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other?.Price);
        }

        public override string ToString()
        {
            return $"{FlightNumber} | ₹{Price} | {Duration} | {DepartureTime:t}";
        }
        
    }  

    class FlightDurationComparer : IComparer<Flight>
    {
        public int Compare(Flight x, Flight y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Duration.CompareTo(y.Duration);
        }
    }
    class FlightDepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight x, Flight y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.DepartureTime.CompareTo(y.DepartureTime);
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
        List<Flight> flights = new List<Flight>
        {
            new Flight("AI101", 5500, TimeSpan.FromHours(2.5), DateTime.Today.AddHours(9)),
            new Flight("UK202", 4200, TimeSpan.FromHours(3), DateTime.Today.AddHours(6)),
            new Flight("SG303", 6200, TimeSpan.FromHours(2), DateTime.Today.AddHours(11)),
            new Flight("IN404", 4200, TimeSpan.FromHours(1.8), DateTime.Today.AddHours(7)),
            new Flight("EM505", 7800, TimeSpan.FromHours(4),   DateTime.Today.AddHours(5.5)),
            new Flight("QA606", 5500, TimeSpan.FromHours(2),   DateTime.Today.AddHours(8))
        };

        Console.WriteLine("---- Economy View ----\n");
        flights.Sort();
        System.Console.WriteLine("F.No: | Price | Duration | Departure Time");
        System.Console.WriteLine();
        foreach (var flight in flights)
        {
            Console.WriteLine(flight);
        }

        Console.WriteLine("\n---- Business Runner View ------\n");
        flights.Sort(new FlightDurationComparer());
        System.Console.WriteLine("F.No: | Price | Duration | Departure Time");
        System.Console.WriteLine();
        foreach (var flight in flights)
        {
            Console.WriteLine(flight);
        }

        Console.WriteLine("\n---- Early Bird View ----\n");
        flights.Sort(new FlightDepartureComparer());
        System.Console.WriteLine("F.No: | Price | Duration | Departure Time");
        System.Console.WriteLine();
        foreach (var flight in flights)
        {
            Console.WriteLine(flight);
       
        }
        }
    }
}
