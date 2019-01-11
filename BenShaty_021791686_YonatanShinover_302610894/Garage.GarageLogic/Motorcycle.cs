using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is the Motorcycle Class inheriting from Vehicle
    /// </summary>
    class Motorcycle : Vehicle
    {
        /// <summary>
        /// The License type of the Motorcycle
        /// </summary>
        public E_LicenseType LicenseType { get; set; }
        /// <summary>
        /// This is the Engine Volume of the Motorcycle
        /// </summary>
        public int EngineVolume { get; set; }
        public Motorcycle(E_LicenseType licenseType, int engineVolume,
            E_VehicleType vehicleType, string vehicleModel, string vehicleLicensePlate,
            string ownerName, string OwnerPhone, E_VehicleStateInGarage vehicleState,
            string wheelManufacturerName, Engine vehicleEngine)
            : base(vehicleType, vehicleModel, vehicleLicensePlate, ownerName, OwnerPhone, vehicleState,
                  wheelManufacturerName, vehicleEngine)
        {
            LicenseType = licenseType;
            EngineVolume = engineVolume;
        }
    }
}
