using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is the Vehicle class
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// This is the Vehicle model firm
        /// </summary>
        public string VehicleModel { get; set; }
        /// <summary>
        /// This is the Vehicle License Plate
        /// </summary>
        public string VehicleLicensePlate { get; set; }
        /// <summary>
        /// set the vehicle type
        /// </summary>
        public E_VehicleType VehicleType { get; set; }
        /// <summary>
        /// This is the owner of the vehicle name
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// This is the owner of the vehicle Phone number
        /// </summary>
        public string OwnerPhone { get; set; }
        /// <summary>
        /// This is the Vehicle status in the garage
        /// </summary>
        public E_VehicleStateInGarage VehicleStateInGarage { get; set; }
        /// <summary>
        /// This is the creation of 4 wheels array object
        /// </summary>
        public Wheel[] VehicleWheels = new Wheel[4];
        /// <summary>
        /// This is the Vehicle engine type
        /// </summary>
        public Engine VehicleEngine { get; set; }
        public Vehicle(E_VehicleType vehicleType ,string vehicleModel, string vehicleLicensePlate, string ownerName, 
            string ownerPhone, E_VehicleStateInGarage vehicleState, string wheelManufacturerName, Engine vehicleEngine)
        {
            float maxAirPresureByVehicleType;
            VehicleLicensePlate = vehicleLicensePlate;
            OwnerName = ownerName;
            OwnerPhone = ownerPhone;
            VehicleStateInGarage = vehicleState;
            VehicleEngine = vehicleEngine;
            VehicleModel = vehicleModel;
            switch (vehicleType)
            {
                case E_VehicleType.Bike:
                    maxAirPresureByVehicleType = 28.0f;
                    break;
                case E_VehicleType.Car:
                    maxAirPresureByVehicleType = 32.0f;
                    break;
                case E_VehicleType.Truck:
                    maxAirPresureByVehicleType = 34.0f;
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }

            for (int i = 0; i < 4; i++)
            {
                VehicleWheels[i] = new Wheel(wheelManufacturerName, maxAirPresureByVehicleType);
            }
            VehicleEngine = vehicleEngine;
        }
        /// <summary>
        /// Override ToString method.
        /// return string of all vehicle details
        /// </summary>
        /// <returns>string of all vehicle details</returns>
        public override string ToString()
        {
            // set basic properties text to result
            string res =  "Vehicle: "+ VehicleLicensePlate + ", Model: " + VehicleModel + ", Owner: " + 
                OwnerName + ", Owner phone: " + OwnerPhone + ", State in Garage: " + VehicleStateInGarage + ", ";
            // foreach loop to get all wheels details
            foreach (var wheel in VehicleWheels)
            {
                // add details to result string
                res += wheel.ManufacturerName + ", " + wheel.WheelAirPresure + ", ";
            }
            // add engine type to result string
            res += VehicleEngine.EngineType + ", " + VehicleEngine.CurrentAmount + ", ";
            // check if engine type is fuel and add data to result string
            switch (VehicleEngine.EngineType)
            {
                case E_EngineType.Fuel:
                    // cast the engine to fuel type
                    var tempEngine = (Gasoline)VehicleEngine;
                    // add fuel engine fuel type
                    res += tempEngine.FuelType + " ";
                    break;
                case E_EngineType.Electric:
                    break;
                default:
                    // no engine type is defined
                    throw new ArgumentException("Not defined vehicle engine type");
            }
            // return result as string
            return res;
        }
    }
}
