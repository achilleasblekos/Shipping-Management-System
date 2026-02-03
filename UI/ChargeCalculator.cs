using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingSystem.Domain;

namespace ShippingSystem.UI
{
    public class ChargeCalculator
    {
        private List<Ship> ships;

        public ChargeCalculator(List<Ship> ships)
        {
            this.ships = ships;
        }

        public void Show()
        {
            Console.WriteLine("\n=== CHARGE CALCULATOR SCREEN ===");

            Console.WriteLine("Select a ship to calculate total charge:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i].Name}");
            }
            Console.WriteLine($"{ships.Count + 1}. Back to Main Menu");

            Console.Write("Choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice > 0 && choice <= ships.Count)
                {

                    Ship selected = ships[choice - 1];
                    Console.WriteLine($"\n--> Total Charge for '{selected.Name}': {selected.GetTotalCharge()} Euro");

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else if (choice == ships.Count + 1)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Press any key...");
                    Console.ReadKey();
                }
            }
        }
    }
}