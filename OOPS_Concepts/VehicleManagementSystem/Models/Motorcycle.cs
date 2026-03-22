using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem.Models
{
    public class Motorcycle : FuelVehicle
    {
        public bool HasSidecar { get; }

        public Motorcycle(
            string manufacturer, string model, int year, double price,
            double initialFuel, bool hasSidecar = false)
            : base(manufacturer, model, year, price, initialFuel)
        {
            HasSidecar = hasSidecar;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"[Motorcycle]   {Year} {Manufacturer} {Model,-20} " +
                $"Price: ${Price,8:N0}  Fuel: {FuelLevel:F1}%  Sidecar: {HasSidecar}");
        }
    }
}
