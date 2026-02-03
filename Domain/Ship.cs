using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingSystem.Domain
{
    public class Ship
    {
        public string? Name { get; private set; }
        public int Capacity { get; private set; }
        private List<Container> containers = new List<Container>();

        public Ship(string? name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public void AddContainer(Container aContainer)
        {
            if (containers.Count < Capacity)
            {
                containers.Add(aContainer);
                Console.WriteLine($"[SUCCESS] Container added to {Name}.");
            }
            else
            {
                Console.WriteLine("Sorry, the ship is full");
            }
        }

        public double GetTotalCharge()
        {
            double totalCharge = 0;
            foreach (var container in containers)
            {
                totalCharge += container.GetCharge();
            }
            return totalCharge;
        }
    }
}
