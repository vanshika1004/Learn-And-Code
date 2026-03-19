using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagementSystem.Manager;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=== Vehicle Management System ===\n");

            var car = new Car("Honda", "Accord", 2023, 28_000, initialFuel: 100);
            var motorcycle = new Motorcycle("Harley-Davidson", "Street 750", 2022, 7_500, initialFuel: 80);
            var electricCar = new ElectricCar("Tesla", "Model 3", 2023, 42_000, initialBattery: 100);

            
            Console.WriteLine("Testing Vehicles");
            car.Start();
            car.DisplayInfo();
            car.Refuel(10);
            car.Stop();

            Console.WriteLine();
            motorcycle.Start();
            motorcycle.DisplayInfo();

            Console.WriteLine();
            electricCar.Start();
            electricCar.DisplayInfo();
            electricCar.Charge(15);


            var manager = new VehicleManager();
            manager.AddVehicle(car);
            manager.AddVehicle(motorcycle);
            manager.AddVehicle(electricCar);

            manager.DisplayAll();
            Console.WriteLine($"\nTotal value: ${manager.CalculateTotalValue():N0}");

            manager.StartAllVehicles();
            manager.StopAllVehicles();

            Console.WriteLine("\n=== Encapsulation Validation === ");

            try { var bad = new Car("Test", "Car", 2020, -500, 50); }
            catch (ArgumentOutOfRangeException ex)
            { Console.WriteLine($"Blocked negative price: {ex.ParamName}"); }

            try { car.Refuel(9999); }
            catch (Exception ex)
            { Console.WriteLine($"Blocked overflow fuel: {ex.Message}"); }

            Console.WriteLine("\n=== Done ===");
        }
    }
}
