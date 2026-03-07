using System;
using System.Collections.Generic;
using System.Linq;
using SaaSArchitect.Models;
using SaaSArchitect.Services;

namespace SaaSArchitect
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Subscriber> subscribers = new Dictionary<string, Subscriber>();

            
            subscribers["alice@company.com"] = new BusinessSubscriber(
                Guid.NewGuid(), "Alice Corp", new DateTime(2023, 5, 1), 500, 0.18m);

            subscribers["bob@company.com"] = new BusinessSubscriber(
                Guid.NewGuid(), "Bob Ltd", new DateTime(2022, 11, 10), 700, 0.15m);

            subscribers["john@gmail.com"] = new ConsumerSubscriber(
                Guid.NewGuid(), "John", new DateTime(2024, 1, 12), 40, 2.5m);

            subscribers["emma@gmail.com"] = new ConsumerSubscriber(
                Guid.NewGuid(), "Emma", new DateTime(2023, 7, 18), 25, 3m);

            subscribers["liam@gmail.com"] = new ConsumerSubscriber(
                Guid.NewGuid(), "Liam", new DateTime(2023, 3, 9), 60, 2m);

         
            var sortedSubscribers = subscribers
                .OrderByDescending(s => s.Value.CalculateMonthlyBill())
                .Select(s => s.Value)
                .ToList();

      
            ReportGenerator.PrintRevenueReport(sortedSubscribers);
        }
    }
}