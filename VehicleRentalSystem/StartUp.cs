using System;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem
{
    internal class StartUp
    {

        static void Main(string[] args)
        {
            PrintCarInvoice();
            PrintMotorcycleInvoice();
            PrintCargoVanInvoice();
        }

        private static void PrintCargoVanInvoice()
        {
            CargoVan cargoVan = new CargoVan("Citroen", "Jumper", 20000, 8);
            string customerName = "John Markson";

            DateTime reservationStartDate = DateTime.Parse("2024-06-03");
            DateTime reservationEndDate = DateTime.Parse("2024-06-18");
            DateTime actualReturnDate = DateTime.Parse("2024-06-13");

            Invoice cargoVanInvoice = new Invoice(customerName, cargoVan, reservationStartDate, reservationEndDate, actualReturnDate);
            string cargoVanInvoiceString = cargoVanInvoice.GenerateInvoice();

            Console.WriteLine($"A cargo van valued at ${cargoVan.VehicleValue:F2}, and the driver has {cargoVan.DriverExperience} years of driving experience");
            Console.WriteLine();
            Console.WriteLine(cargoVanInvoiceString);
        }

        private static void PrintMotorcycleInvoice()
        {
            Motorcycle motorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 20);
            string customerName = "Mary Johnson";

            DateTime reservationStartDate = DateTime.Parse("2024-06-03");
            DateTime reservationEndDate = DateTime.Parse("2024-06-13");
            DateTime actualReturnDate = DateTime.Parse("2024-06-13");

            Invoice motorcycleInvoice = new Invoice(customerName, motorcycle, reservationStartDate, reservationEndDate, actualReturnDate);
            string motorcycleInvoiceString = motorcycleInvoice.GenerateInvoice();

            Console.WriteLine($"A motorcycle valued at ${motorcycle.VehicleValue:F2}, and the driver is {motorcycle.RiderAge} years old");
            Console.WriteLine();
            Console.WriteLine(motorcycleInvoiceString);
        }

        private static void PrintCarInvoice()
        {
            Car car = new Car("Mitsubishi", "Mirage", 15000m, Common.CarSafetyRating.Medium);
            string customerName = "John Doe";

            DateTime reservationStartDate = DateTime.Parse("2024-06-03");
            DateTime reservationEndDate = DateTime.Parse("2024-06-13");
            DateTime actualReturnDate = DateTime.Parse("2024-06-13");

            Invoice carInvoice = new Invoice(customerName, car, reservationStartDate, reservationEndDate, actualReturnDate);
            string carInvoiceString = carInvoice.GenerateInvoice();

            Console.WriteLine($"A car that is valued at ${car.VehicleValue:F2}, and has a security rating of {(int)car.SafetyRating}:");
            Console.WriteLine();
            Console.WriteLine(carInvoiceString);
        }
    }
}