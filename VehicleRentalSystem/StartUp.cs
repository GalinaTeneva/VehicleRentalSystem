using System;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem
{
    internal class StartUp
    {

        static void Main(string[] args)
        {
            Car car = new Car("Mitsubishi", "Mirage", 15000, Common.CarSafetyRating.Medium);
        }
    }
}