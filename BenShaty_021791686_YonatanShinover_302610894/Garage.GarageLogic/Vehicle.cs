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
        /// <summary>
        /// the owner of the vehicle name
        /// </summary>
        public string OwnerName { get; private set; }
        public string OwnerPhone { get; set; }
        public E_VehicleStateInGarage VehicleStateInGarage { get; set; }
        public Wheel[] VehicleWheels = new Wheel[4];
        public Engine VehicleEngine { get; set; }
        public override string ToString()
        {
            
            string res =  "Vehicle: "+ VehicleLicencePlate + ", " + VehicleModel + ", " + OwnerName + ", " + OwnerPhone + ", " + VehicleStateInGarage + " ";
            foreach (var wheel in VehicleWheels)
            {
                res += wheel.ManufacturerName + " " + wheel.WheelAirPresure + " ";
            }
            res += VehicleEngine.EngineType + " " + VehicleEngine.CurrentAmount + " ";
            switch (VehicleEngine.EngineType)
            {
                case E_EngineType.Fuel:
                    var tempEngine = (Gasoline)VehicleEngine;
                    res += tempEngine.FuelType + " ";
                    break;
                case E_EngineType.Electric:
                    break;
                default:
                    throw new ArgumentException("Not defined vehicle engine type");
            }
            return res;
        }
    }
}
