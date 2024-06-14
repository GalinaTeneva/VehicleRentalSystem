using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Models.Interfaces
{
    internal interface IVehicle
    {
        public string VehicleBrand { get; }
        public string VehicleModel { get; }
        public decimal VehicleValue { get; }

        public int RentalPeriod { get; }
    }
}
