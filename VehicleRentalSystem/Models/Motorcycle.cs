namespace VehicleRentalSystem.Models
{
    public class Motorcycle : Vehicle
    {
        private int riderAge;

        public Motorcycle(string brand, string model, decimal vehicleValue, int riderAge) 
            : base(brand, model, vehicleValue)
        {
            this.RiderAge = riderAge;
        }

        public int RiderAge
        {
            get { return this.riderAge; }
            set { this.riderAge = value; }
        }
    }
}
