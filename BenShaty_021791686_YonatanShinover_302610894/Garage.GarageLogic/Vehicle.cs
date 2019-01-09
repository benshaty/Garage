using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    class Vehicle
    {
        public string VehicleModel { get; set; }
        public string VehicleLicencePlate { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public Engine VehicleEngine { get; set; }
        public E_VehicleStateInGarage VehicleStateInGarage { get; set; }

    }
}
