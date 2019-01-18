using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is the Truck Class inheriting from Vehicle
    /// </summary>
   public class Truck : Vehicle
    {
        /// <summary>
        /// This is the True/False Hazardous materials status of the Truck 
        /// </summary>
        public bool HazardousMaterials { get; set; }
        /// <summary>
        /// This is the Max weight amount a Truck can carrey
        /// </summary>
        public float MaxWeight { get; set; }
        public Truck(bool hezerdosMat, float maxWeight,
            E_VehicleType vehicleType, string vehicleModel, string vehicleLicensePlate,
            string ownerName, string OwnerPhone, E_VehicleStateInGarage vehicleState,
            string wheelManufacturerName, Engine vehicleEngine)
            : base(vehicleType, vehicleModel, vehicleLicensePlate, ownerName, OwnerPhone, vehicleState,
                  wheelManufacturerName, vehicleEngine)
        {
            HazardousMaterials = hezerdosMat;
            MaxWeight = maxWeight;
            NumOfWheels = E_NumOfWheels.Four;
        }

    }
}
