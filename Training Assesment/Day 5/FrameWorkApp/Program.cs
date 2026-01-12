using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GreetingLibrary;

namespace GreetingApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            string message = GreetingHelper.GetGreeting(name);
            Console.WriteLine(message);

            Console.ReadLine();
        }
    }
}

