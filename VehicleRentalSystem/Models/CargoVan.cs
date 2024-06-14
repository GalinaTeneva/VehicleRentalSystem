using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Models
{
    public class CargoVan : Vehicle
    {
        private int driverExperience;

        public CargoVan(string brand, string model, decimal vehicleValue, int period) 
            : base(brand, model, vehicleValue, period)
        {
        }

        public int DriverExperience
        {
            get { return this.driverExperience; }
            set { this.driverExperience = value; }
        }
    }
}
