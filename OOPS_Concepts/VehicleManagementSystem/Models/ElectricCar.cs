using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem.Models
{

    public class ElectricCar : Vehicle
    {
        private double _batteryLevel;

        public double BatteryLevel
        {
            get => _batteryLevel;
            private set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(BatteryLevel),
                        "Battery level must be between 0 and 100%.");
                _batteryLevel = value;
            }
        }

        public ElectricCar(string manufacturer, string model, int year, double price, double initialBattery)
            : base(manufacturer, model, year, price)
        {
            BatteryLevel = initialBattery;
        }

        public void Charge(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Charge amount must be positive.");

            BatteryLevel = Math.Min(BatteryLevel + amount, 100);
            Console.WriteLine($"Charged {Manufacturer} {Model}. Battery level: {BatteryLevel:F1}%");
        }

        public override void Start()
        {
            if (BatteryLevel <= 0)
            {
                Console.WriteLine($"{Manufacturer} {Model} cannot start — battery dead!");
                return;
            }
            SetRunning(true);
            Console.WriteLine($"{Manufacturer} {Model} electric motor started.");
        }

        public override void Stop()
        {
            SetRunning(false);
            Console.WriteLine($"{Manufacturer} {Model} stopped.");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"[Electric Car] {Year} {Manufacturer} {Model,-20} " +
                $"Price: ${Price,8:N0}  Battery: {BatteryLevel:F1}%");
        }
    }
}
