using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem
{
    public class Invoice
    {
        private string customerName;
        private Vehicle rentedVehicle;
        private DateTime reservationStartDate;
        private DateTime reservationEndDate;
        private DateTime actualReturnDate;
        private RentalCalculator calculator;

        public Invoice(string customerName, Vehicle rentedVehicle, DateTime reservationStartDate, DateTime reservationEndDate, DateTime actualReturnDate)
        {
            this.calculator = new RentalCalculator();
            this.customerName = customerName;
            this.rentedVehicle = rentedVehicle;
            this.reservationStartDate = reservationStartDate;
            this.reservationEndDate = reservationEndDate;
            this.actualReturnDate = actualReturnDate;
        }

        public string GenerateInvoice()
        {
            StringBuilder sb = new StringBuilder();

            decimal totalRentalCost = calculator.CalcTotalRentalCost(rentedVehicle, reservationStartDate, reservationEndDate, actualReturnDate);
            decimal totalInsuranceCost = calculator.CalcTotalInsuranceCost(rentedVehicle, reservationStartDate, reservationEndDate, actualReturnDate);
            int reservedRentalDays = calculator.CalcRentalPeriod(reservationStartDate, reservationEndDate);
            int actualRentalDays = calculator.CalcRentalPeriod(reservationStartDate, actualReturnDate);

            sb.AppendLine("XXXXXXXXXX");
            sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Customer Name: {customerName}");
            sb.AppendLine($"Rented Vehicle: {rentedVehicle.VehicleBrand} {rentedVehicle.VehicleModel}").AppendLine();

            sb.AppendLine($"Reservation start date: {reservationStartDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Reservation end date: {reservationEndDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Reserved rental days:{reservedRentalDays} days").AppendLine();

            sb.AppendLine($"Actual Return date: {actualReturnDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Actual rental days: {actualRentalDays} days").AppendLine();

            //Edit RentalCalculator in order to fill in the lines below!!!
            sb.AppendLine("Rental cost per day: ");
            sb.AppendLine("Initial insurance per day: ");
            sb.AppendLine("Insurance discount per day: ");
            sb.AppendLine("Insurance per day: ").AppendLine();

            sb.AppendLine("Early return discount for rent: ");
            sb.AppendLine("Early return discount for insurance: ").AppendLine();

            sb.AppendLine("Total rent: ");
            sb.AppendLine("Total Insurance: ");
            sb.AppendLine("Total: ");
            sb.AppendLine("XXXXXXXXXX");

            return sb.ToString();
        }
    }
}
