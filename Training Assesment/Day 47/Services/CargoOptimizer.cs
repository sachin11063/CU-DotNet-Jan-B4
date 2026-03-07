using System;
using System.Collections.Generic;
using System.Linq;
using CargoManifestOptimizer.Models;

namespace CargoManifestOptimizer.Services
{
    public class CargoOptimizer
    {
        private readonly List<List<Container>> cargoBay;

        public CargoOptimizer(List<List<Container>> cargoBay)
        {
            this.cargoBay = cargoBay ?? new List<List<Container>>();
        }

        // Task A: Find containers whose total weight exceeds threshold
        public List<string> FindHeavyContainers(double weightThreshold)
        {
            var result = new List<string>();

            foreach (var row in cargoBay)
            {
                if (row == null) continue;

                foreach (var container in row)
                {
                    if (container?.Items == null) continue;

                    double totalWeight = container.Items.Sum(i => i.Weight);

                    if (totalWeight > weightThreshold)
                        result.Add(container.ContainerID);
                }
            }

            return result;
        }

        // Task B: Count items by category
        public Dictionary<string, int> GetItemCountsByCategory()
        {
            return cargoBay
                .Where(row => row != null)
                .SelectMany(row => row)
                .Where(container => container?.Items != null)
                .SelectMany(container => container.Items)
                .GroupBy(item => item.Category)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // Task C: Flatten, remove duplicates, and sort
        public List<Item> FlattenAndSortShipment()
        {
            return cargoBay
                .Where(row => row != null)
                .SelectMany(row => row)
                .Where(container => container?.Items != null)
                .SelectMany(container => container.Items)
                .GroupBy(item => item.Name) // remove duplicates
                .Select(g => g.First())
                .OrderBy(item => item.Category)
                .ThenByDescending(item => item.Weight)
                .ToList();
        }
    }
}