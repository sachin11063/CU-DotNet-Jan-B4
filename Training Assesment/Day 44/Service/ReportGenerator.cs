using System;
using System.Collections.Generic;
using System.Text;
using SaaSArchitect.Models;

namespace SaaSArchitect.Services
{
    public static class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("====== SaaS Revenue Report ======");
            sb.AppendLine("Name\t\tType\t\tMonthly Bill");
            sb.AppendLine("---------------------------------------");

            foreach (var sub in subscribers)
            {
                string type = sub is BusinessSubscriber ? "Business" : "Consumer";

                sb.AppendLine($"{sub.Name}\t\t{type}\t\t{sub.CalculateMonthlyBill():C}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}