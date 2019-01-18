using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is the Car Class inheriting from Vehicle
    /// </summary>
    public class Car : Vehicle
    {
        /// <summary>
        /// This is the Color of the Car
        /// </summary>
        public E_Color Color { get; set; }
        /// <summary>
        /// This is the Doors number of a Car
        /// </summary>
        public E_NumOfDoors Doors { get; set; }
        public Car(E_Color carColor, E_NumOfDoors carNumOfDoors, 
            E_VehicleType vehicleType, string vehicleModel, string vehicleLicensePlate, 
            string ownerName,string OwnerPhone, E_VehicleStateInGarage vehicleState, 
            string wheelManufacturerName, Engine vehicleEngine) 
            : base(vehicleType,vehicleModel,vehicleLicensePlate,ownerName,OwnerPhone,vehicleState,
                  wheelManufacturerName,vehicleEngine)
        {
            Color = carColor;
            Doors = carNumOfDoors;
            NumOfWheels = E_NumOfWheels.Four;
        }
    }
}
