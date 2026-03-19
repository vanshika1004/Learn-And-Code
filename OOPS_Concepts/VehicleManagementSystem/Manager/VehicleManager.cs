using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagementSystem.Interfaces;

namespace VehicleManagementSystem.Manager
{
    public class VehicleManager
    {
        private readonly List<IVehicle> _vehicles = new List<IVehicle>();

        public IReadOnlyList<IVehicle> Vehicles => _vehicles.AsReadOnly();

        public void AddVehicle(IVehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));
            _vehicles.Add(vehicle);
            Console.WriteLine($"Added: {vehicle.Manufacturer} {vehicle.Model} ({vehicle.GetType().Name})");
        }

        public void DisplayAll()
        {
            Console.WriteLine("\n===  Displaying Vehicles Info===");
            if (_vehicles.Count == 0)
            {
                Console.WriteLine("  (no vehicles)");
                return;
            }
            foreach (var vehicle in _vehicles)
                vehicle.DisplayInfo();
        }

        public double CalculateTotalValue()
        {
            double total = 0;
            foreach (var vehicle in _vehicles)
                total += vehicle.Price;
            return total;
        }

        public void StartAllVehicles()
        {
            Console.WriteLine("\n--- Starting all vehicles ---");
            foreach (var vehicle in _vehicles)
                vehicle.Start();
        }

        public void StopAllVehicles()
        {
            Console.WriteLine("\n--- Stopping all vehicles ---");
            foreach (var vehicle in _vehicles)
                vehicle.Stop();
        }
    }
}
