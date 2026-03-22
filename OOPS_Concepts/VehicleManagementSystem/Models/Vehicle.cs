using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagementSystem.Interfaces;

namespace VehicleManagementSystem.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string _manufacturer = string.Empty;
        private string _model = string.Empty;
        private int _year;
        private double _price;

        protected bool _isRunning;

        public string Manufacturer
        {
            get => _manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Manufacturer cannot be empty.");
                _manufacturer = value;
            }
        }

        public string Model
        {
            get => _model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Model cannot be empty.");
                _model = value;
            }
        }

        public int Year
        {
            get => _year;
            private set
            {
                if (value < 1886 || value > DateTime.Now.Year + 1)
                    throw new ArgumentOutOfRangeException(nameof(Year), "Invalid manufacture year.");
                _year = value;
            }
        }

        public double Price
        {
            get => _price;
            private set
            {
                if (value < 0 || value > 1_000_000)
                    throw new ArgumentOutOfRangeException(nameof(Price),
                        "Price must be between $0 and $1,000,000.");
                _price = value;
            }
        }

        public bool IsRunning => _isRunning;

        protected Vehicle(string manufacturer, string model, int year, double price)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            Price = price;
        }

        // Subclasses call this instead of touching _isRunning directly
        protected void SetRunning(bool value) => _isRunning = value;

        public abstract void Start();
        public abstract void Stop();
        public abstract void DisplayInfo();
    }
}
