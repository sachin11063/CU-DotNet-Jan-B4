using System.Collections.Generic;

namespace CargoManifestOptimizer.Models
{
    public class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items { get; set; }

        public Container(string containerID, List<Item> items)
        {
            ContainerID = containerID;
            Items = items ?? new List<Item>();
        }
    }
}