using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem.Models
{
    public abstract class FuelVehicle : Vehicle
    {
        private double _fuelLevel;

        public double FuelLevel
        {
            get => _fuelLevel;
            private set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(FuelLevel),
                        "Fuel level must be between 0 and 100%.");
                _fuelLevel = value;
            }
        }

        protected FuelVehicle(string manufacturer, string model, int year, double price, double initialFuel)
            : base(manufacturer, model, year, price)
        {
            FuelLevel = initialFuel;
        }

        public void Refuel(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Refuel amount must be positive.");

            FuelLevel = Math.Min(FuelLevel + amount, 100);
            Console.WriteLine($"Refueled {Manufacturer} {Model}. Fuel level: {FuelLevel:F1}%");
        }

        public override void Start()
        {
            if (FuelLevel <= 0)
            {
                Console.WriteLine($"{Manufacturer} {Model} cannot start — no fuel!");
                return;
            }
            SetRunning(true);
            Console.WriteLine($"{Manufacturer} {Model} engine started.");
        }

        public override void Stop()
        {
            SetRunning(false);
            Console.WriteLine($"{Manufacturer} {Model} stopped.");
        }
    }
}
