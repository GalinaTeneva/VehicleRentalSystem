using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalSystem.Common;

namespace VehicleRentalSystem.Models
{
    public class Car : Vehicle
    {
        private CarSafetyRating safetyRating;

        public Car(string brand, string model, decimal vehicleValue, CarSafetyRating safetyRating) 
            : base(brand, model, vehicleValue)
        {
            this.safetyRating = safetyRating;
        }

        public CarSafetyRating SafetyRating
        {
            get { return safetyRating; }
            set { safetyRating = value; }
        }
    }
}
