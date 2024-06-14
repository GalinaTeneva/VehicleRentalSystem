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

        public void PrintInvoice()
        {
            
        }
    }
}
