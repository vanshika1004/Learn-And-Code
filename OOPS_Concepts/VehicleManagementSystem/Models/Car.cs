using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem.Models
{
    public class Car : FuelVehicle
    {
        public Car(string manufacturer, string model, int year, double price, double initialFuel)
            : base(manufacturer, model, year, price, initialFuel) { }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"[Car]          {Year} {Manufacturer} {Model,-20} " +
                $"Price: ${Price,8:N0}  Fuel: {FuelLevel:F1}%");
        }
    }
}
