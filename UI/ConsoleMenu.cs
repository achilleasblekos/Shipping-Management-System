using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingSystem.Domain;

namespace ShippingSystem.UI
{
    public class ConsoleMenu
    {
        private List<Ship>? ships;

        public ConsoleMenu(List<Ship>? ships)
        {
            this.ships = ships;
        }

        public void Show()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== SHIPPING MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Create Container (Open ContainerFrame)");
                Console.WriteLine("2. Calculate Charge (Open ChargeCalculator)");
                Console.WriteLine("3. Exit");
                Console.Write("Select: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowContainerFrame();
                        break;
                    case "2":
                        if (ships != null)
                        {
                            ChargeCalculator calculator = new ChargeCalculator(ships);
                            calculator.Show();
                        }
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void ShowContainerFrame()
        {
            Console.WriteLine("\n--- CONTAINER CREATION FRAME ---");

            Ship? selectedShip = SelectShip();
            if (selectedShip == null) return;

            Console.Write("Enter Code: ");
            string code = Console.ReadLine() ?? "";

            Console.Write("Enter Destination: ");
            string dest = Console.ReadLine() ?? "";


            Console.WriteLine("Type: (B)ulk or (R)efrigerator?");
            string type = (Console.ReadLine() ?? "").ToUpper();

            if (type == "B")
            {
                Console.Write("Enter Weight (kg): ");
                if (int.TryParse(Console.ReadLine(), out int weight))
                {

                    BulkContainer newBulkContainer = new BulkContainer(code, dest, weight);
                    selectedShip.AddContainer(newBulkContainer);
                    Console.WriteLine($"[INFO] Container added. Total Charge for {selectedShip.Name}: {selectedShip.GetTotalCharge()} Euro");
                }
                else
                {
                    Console.WriteLine("Invalid weight format.");
                }
            }
            else if (type == "R")
            {
                Console.Write("Enter Power (kW): ");
                if (double.TryParse(Console.ReadLine(), out double power))
                {
                    RefrigeratorContainer newRef = new RefrigeratorContainer(code, dest, power);
                    selectedShip.AddContainer(newRef);

                    Console.WriteLine($"[INFO] Container added. Total Charge for {selectedShip.Name}: {selectedShip.GetTotalCharge()} Euro");
                }
                else
                {
                    Console.WriteLine("Invalid power format.");
                }
            }
            else
            {
                Console.WriteLine("Unknown container type.");
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private Ship? SelectShip()
        {
            Console.WriteLine("\nAvailable Ships:");
            if (ships != null)
            {
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ships[i].Name} (Capacity: {ships[i].Capacity})");
                }
                Console.Write("Select Ship Number: ");

                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= ships.Count)
                {
                    return ships[index - 1];
                }
            }

            Console.WriteLine("Invalid selection.");
            return null;
        }

    }
}