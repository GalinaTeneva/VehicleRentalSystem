using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalSystem.Models.Interfaces;

namespace VehicleRentalSystem.Models
{
    public class Vehicle : IVehicle
    {
        private string vehicleBrand;
        private string vehicleModel;
        private decimal vehicleValue;

        public Vehicle(string brand, string model, decimal value)
        {
            this.VehicleBrand = brand;
            this.VehicleModel = model;
            this.VehicleValue = value;
        }

        public string VehicleBrand
        {
            get { return this.vehicleBrand; }
            set { this.vehicleBrand = value; }
        }

        public string VehicleModel
        {
            get { return this.vehicleModel; }
            set { this.vehicleModel = value; }
        }

        public decimal VehicleValue
        {
            get { return this.vehicleValue; }
            set { this.vehicleValue = value; }
        }
    }
}
