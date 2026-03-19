using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem.Interfaces
{
    public interface IVehicle
    {
        string Manufacturer { get; }
        string Model { get; }
        int Year { get; }
        double Price { get; }
        bool IsRunning { get; }

        void Start();
        void Stop();
        void DisplayInfo();
    }
}
