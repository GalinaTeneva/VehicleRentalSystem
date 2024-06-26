﻿using VehicleRentalSystem.Models.Interfaces;

namespace VehicleRentalSystem.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string vehicleBrand;
        private string vehicleModel;
        private decimal vehicleValue;

        public Vehicle(string brand, string model, decimal vehicleValue)
        {
            this.VehicleBrand = brand;
            this.VehicleModel = model;
            this.VehicleValue = vehicleValue;
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
