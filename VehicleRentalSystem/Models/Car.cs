using VehicleRentalSystem.Common;

namespace VehicleRentalSystem.Models
{
    public class Car : Vehicle
    {
        private CarSafetyRating safetyRating;

        public Car(string brand, string model, decimal vehicleValue, CarSafetyRating safetyRating) 
            : base(brand, model, vehicleValue)
        {
            this.SafetyRating = safetyRating;
        }

        public CarSafetyRating SafetyRating
        {
            get { return safetyRating; }
            set { safetyRating = value; }
        }
    }
}
