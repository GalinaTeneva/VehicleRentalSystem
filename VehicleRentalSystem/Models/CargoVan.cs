namespace VehicleRentalSystem.Models
{
    public class CargoVan : Vehicle
    {
        private int driverExperience;

        public CargoVan(string brand, string model, decimal vehicleValue, int driverExperience) 
            : base(brand, model, vehicleValue)
        {
            this.DriverExperience = driverExperience;
        }

        public int DriverExperience
        {
            get { return this.driverExperience; }
            set { this.driverExperience = value; }
        }
    }
}
