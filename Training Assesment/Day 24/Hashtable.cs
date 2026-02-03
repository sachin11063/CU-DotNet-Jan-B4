using System.Collections.Hashtable;
using System.Runtime.InteropServices;

namespace OOPSLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");  
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");

            if (employeeTable.ContainsKey(105))
            {
                Console.WriteLine("ID Already exists.");
            }
            else
            {
                employeeTable.Add(105, "Edward");
            }

            string name = (string)employeeTable[102];

            foreach (DictionaryEntry item in employeeTable)
            {
                Console.WriteLine($"ID: {item.Key}, Name: {item.Value}");
            }

            employeeTable.Remove(103);
            System.Console.WriteLine("Key 103 removed.");
            System.Console.WriteLine("Employee Table Elements Count: " + employeeTable.Count);


        }
    }
}

