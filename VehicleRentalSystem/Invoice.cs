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
            //decimal totalInsuranceCost = calculator.CalcTotalInsuranceCost(rentedVehicle, reservationStartDate, reservationEndDate, actualReturnDate);
            int reservedRentalDays = calculator.CalcRentalPeriod(reservationStartDate, reservationEndDate);
            int actualRentalDays = calculator.CalcRentalPeriod(reservationStartDate, actualReturnDate);

            decimal daylyRentalCost = calculator.GetDailyRentalCost(rentedVehicle, reservedRentalDays);

            decimal baseDailyInsuranceCost = calculator.GetBaseInsuranceCost(rentedVehicle);
            decimal insuranceChange = calculator.GetInsuranceChange(rentedVehicle, reservationStartDate, reservationEndDate, actualReturnDate);

            decimal actualDailyInsuranceCost = insuranceChange == 0 ? baseDailyInsuranceCost : (baseDailyInsuranceCost * insuranceChange);
            decimal totalInsuranceCost = actualDailyInsuranceCost * reservedRentalDays;

            sb.AppendLine("XXXXXXXXXX");
            sb.AppendLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Customer Name: {customerName}");
            sb.AppendLine($"Rented Vehicle: {rentedVehicle.VehicleBrand} {rentedVehicle.VehicleModel}").AppendLine();

            sb.AppendLine($"Reservation start date: {reservationStartDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Reservation end date: {reservationEndDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Reserved rental days: {reservedRentalDays} days").AppendLine();

            sb.AppendLine($"Actual Return date: {actualReturnDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Actual rental days: {actualRentalDays} days").AppendLine();

            sb.AppendLine($"Rental cost per day: ${daylyRentalCost:F2}");

            if (insuranceChange == 0)
            {
                sb.AppendLine($"Insurance per day: ${actualDailyInsuranceCost:F2}").AppendLine();
            }
            else if (insuranceChange > 0)
            {
                decimal insuranceChangeValue = actualDailyInsuranceCost - baseDailyInsuranceCost;
                sb.AppendLine($"Initial insurance per day: ${baseDailyInsuranceCost:F2}");
                sb.AppendLine($"Insurance addition per day: ${insuranceChangeValue:F2}");
                sb.AppendLine($"Insurance per day: ${(actualDailyInsuranceCost):F2}").AppendLine();
            }
            else
            {
                decimal insuranceChangeValue = baseDailyInsuranceCost - actualDailyInsuranceCost;
                sb.AppendLine($"Initial insurance per day: ${baseDailyInsuranceCost:F2}");
                sb.AppendLine($"Insurance addition per day: ${insuranceChangeValue:F2}");
                sb.AppendLine($"Insurance per day: ${(actualDailyInsuranceCost):F2}").AppendLine();
            }

            //sb.AppendLine($"Initial insurance per day: {baseInsuranceCost:C2}");
            //sb.AppendLine("Insurance discount per day: ");

            //sb.AppendLine("Early return discount for rent: ");
            //sb.AppendLine("Early return discount for insurance: ").AppendLine();

            sb.AppendLine($"Total rent: ${totalRentalCost:F2}");
            sb.AppendLine($"Total Insurance: ${totalInsuranceCost:F2}");
            sb.AppendLine($"Total: ${(totalRentalCost + totalInsuranceCost):F2}");
            sb.AppendLine("XXXXXXXXXX");

            return sb.ToString();
        }
    }
}
