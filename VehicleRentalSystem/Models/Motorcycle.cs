using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Models
{
    public class Motorcycle : Vehicle
    {
        private int riderAge;

        public Motorcycle(string brand, string model, decimal vehicleValue, int period, int riderAge) 
            : base(brand, model, vehicleValue)
        {
            this.riderAge = riderAge;
        }

        public int RiderAge
        {
            get { return this.riderAge; }
            set { this.riderAge = value; }
        }
    }
}
