using System;
using System.Collections.Generic;
using CargoManifestOptimizer.Models;
using CargoManifestOptimizer.Services;

class Program
{
    static void Main()
    {
        var cargoBay = new List<List<Container>>
        {
            new List<Container>
            {
                new Container("C001", new List<Item>
                {
                    new Item("Laptop", 2.5, "Tech"),
                    new Item("Monitor", 5.0, "Tech"),
                    new Item("Smartphone", 0.5, "Tech")
                }),

                new Container("C104", new List<Item>
                {
                    new Item("Server Rack", 45.0, "Tech"),
                    new Item("Cables", 1.2, "Tech")
                })
            },

            new List<Container>
            {
                new Container("C002", new List<Item>
                {
                    new Item("Apple", 0.2, "Food"),
                    new Item("Banana", 0.2, "Food"),
                    new Item("Milk", 1.0, "Food")
                }),

                new Container("C003", new List<Item>
                {
                    new Item("Table", 15.0, "Furniture"),
                    new Item("Chair", 7.5, "Furniture")
                })
            },

            new List<Container>
            {
                new Container("C205", new List<Item>
                {
                    new Item("Vase", 3.0, "Decor"),
                    new Item("Mirror", 12.0, "Decor")
                }),

                new Container("C206", new List<Item>())
            },

            new List<Container>()
        };

        var optimizer = new CargoOptimizer(cargoBay);

        // Task A
        var heavy = optimizer.FindHeavyContainers(20);
        Console.WriteLine("Heavy Containers:");
        heavy.ForEach(Console.WriteLine);

        // Task B
        var categories = optimizer.GetItemCountsByCategory();
        Console.WriteLine("\nCategory Counts:");
        foreach (var c in categories)
            Console.WriteLine($"{c.Key}: {c.Value}");

        // Task C
        var items = optimizer.FlattenAndSortShipment();
        Console.WriteLine("\nFlattened Shipment:");
        foreach (var item in items)
            Console.WriteLine($"{item.Category} - {item.Name} ({item.Weight})");
    }
}