using System;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem
{
    public class RentalCalculator
    {
        private readonly decimal carDailyRate;   // daily rate for less than a week
        private readonly decimal carWeeklyRate;  // daily rate for more than a week
        private readonly decimal motorcycleDailyRate;
        private readonly decimal motorcycleWeeklyRate;
        private readonly decimal cargoVanDailyRate;
        private readonly decimal cargoVanWeeklyRate;

        public RentalCalculator()
        {
            this.carDailyRate = 20m;
            this.carWeeklyRate = 15m;
            this.motorcycleDailyRate = 15m;
            this.motorcycleWeeklyRate = 10m;
            this.cargoVanDailyRate = 50m;
            this.cargoVanWeeklyRate = 40m;
        }

        public decimal CalcTotalRentalCost(Vehicle vehicle, DateTime reservationStartDate, DateTime reservationEndDate, DateTime actualReturnDate)
        {
            int reservedDays = CalcRentalPeriod(reservationStartDate, reservationEndDate);
            int actualDays = CalcRentalPeriod(reservationStartDate, actualReturnDate);

            decimal dailyRentalCost = GetDailyRentalCost(vehicle, reservedDays);
            decimal totalCost = dailyRentalCost * actualDays;

            if (actualDays < reservedDays)
            {
                totalCost += (reservedDays - actualDays) * (dailyRentalCost / 2);
            }

            return totalCost;
        }

        public decimal GetInsuranceChange (Vehicle vehicle)
        {
            decimal insuranceChange = 0;

            if (vehicle is Car car)
            {
                if (car.SafetyRating == Common.CarSafetyRating.High || car.SafetyRating == Common.CarSafetyRating.VeryHigh)
                {
                    insuranceChange = 0.9m; // 10% discount for high safety rating
                }
            }
            else if (vehicle is Motorcycle motorcycle)
            {
                if (motorcycle.RiderAge < 25)
                {
                    insuranceChange = 1.2m; // 20% increase for riders under 25
                }
            }
            else if (vehicle is CargoVan cargoVan)
            {
                if (cargoVan.DriverExperience > 5)
                {
                    insuranceChange = 0.85m; // 15% discount for experienced drivers
                }
            }

            return insuranceChange;
        }

        public decimal GetDailyRentalCost(Vehicle vehicle, int reservedDays)
        {
            decimal rentalCost = 0;

            if (vehicle is Car)
            {
                rentalCost = reservedDays > 7 ? carWeeklyRate : carDailyRate;
            }
            else if (vehicle is Motorcycle)
            {
                rentalCost = reservedDays > 7 ? motorcycleWeeklyRate : motorcycleDailyRate;
            }
            else if (vehicle is CargoVan)
            {
                rentalCost = reservedDays > 7 ? cargoVanWeeklyRate : cargoVanDailyRate;
            }

            return rentalCost;
        }

        public decimal GetBaseInsuranceCost(Vehicle vehicle)
        {
            decimal insuranceCost = 0;

            if (vehicle is Car)
            {
                insuranceCost = vehicle.VehicleValue * 0.01m;
            }
            else if (vehicle is Motorcycle)
            {
                insuranceCost = vehicle.VehicleValue * 0.02m;
            }
            else if (vehicle is CargoVan)
            {
                insuranceCost = vehicle.VehicleValue * 0.03m;
            }
            
            return insuranceCost / 100;
        }

        public int CalcRentalPeriod(DateTime startDate, DateTime endDate)
        {
            TimeSpan difference = endDate - startDate;
            return difference.Days;
        }
    }
}
