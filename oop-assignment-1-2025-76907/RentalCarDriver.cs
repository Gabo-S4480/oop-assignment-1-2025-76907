using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Globalization;

namespace oop_assignment_1_2025_76907
{
    internal static class RentalCarDriver
    {
        public static void Run()
        {
            // Set culture for currency display
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            // Declare variables outside try block
            RentalCar car1 = null;
            RentalCar car2 = null;
            RentalCar car3 = null;
            RentalCar car4 = null;

            Console.WriteLine("--- STARTING RentalCar DRIVER TESTS ---");

            try
            {
                // --- 1. CREATION OF AT LEAST 4 OBJECTS (Using the 3 constructors) ---
                car1 = new RentalCar("Toyota", "Yaris", "HatchBack", "RNT-001", 65.00, false);   // Ctor 1
                car2 = new RentalCar("Ford", "Explorer", "CrossOver", "RNT-002", 95.50);         // Ctor 2
                car3 = new RentalCar("Tesla", "Roadster", "Convertible");                        // Ctor 3
                car4 = new RentalCar("Seat", "Arona", "MPV", "RNT-004", 80.00, true);            // Ctor 1 (borrowed)

                Console.WriteLine("\n--- INITIAL DETAILS OF THE 4 CARS ---");
                car1.display();
                car2.display();
                car3.display();
                car4.display();

                // --- 2. CALLING ALL METHODS (Using car1) ---
                Console.WriteLine("\n--- TESTING ALL METHODS (Toyota Yaris RNT-001) ---");

                // borrow() - Should succeed
                car1.borrow();

                // display() - After borrowing
                car1.display();

                // borrow() again - Should fail
                car1.borrow();

                // changePrice()
                car1.changePrice(75.50);

                // checkBorrowed() and checkPrice()
                Console.WriteLine($"[CHECK]: Is it borrowed? {car1.checkBorrowed()}, Current Rate: {car1.checkPrice():C}");

                // returnRentalCar()
                car1.returnRentalCar();

                // display() final
                car1.display();

                // --- 3 (VALIDATION) ---
                Console.WriteLine("\n--- TESTING CONSTRUCTOR EXCEPTIONS ---");

                try
                {
                    RentalCar invalidCar = new RentalCar("Mazda", "3", "Saloon", "REG-000", -10.0, false);
                    invalidCar.display();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error creating invalid car (Expected): {ex.Message}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n[FATAL ERROR IN DRIVER]: Failed during initial object creation: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nRentalCarDriver Run method completed.");
            }
        }
    }
}
