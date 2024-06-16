namespace VehicleRentalSystem.Models.Interfaces
{
    internal interface IVehicle
    {
        public string VehicleBrand { get; }
        public string VehicleModel { get; }
        public decimal VehicleValue { get; }
    }
}
