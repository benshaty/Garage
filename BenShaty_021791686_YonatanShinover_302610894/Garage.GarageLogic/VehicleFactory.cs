using System;

namespace Garage.GarageLogic
{
    /// <summary>
    /// The VehicleFactory main method. Her goal is to create a ready template for each type of vehicle to be ready to set.
    /// </summary>
    public static class VehicleFactory
    {
        /// <summary>
        /// Template for a Motorcycle
        /// </summary>
        /// <param name="currentAmount">float value</param>
        /// <param name="engineType">enum value</param>
        /// <param name="licenseType">enum value</param>
        /// <param name="engineVolume">int value</param>
        /// <param name="vehicleModel">string value</param>
        /// <param name="vehicleLicensePlate">string value</param>
        /// <param name="ownerName">string value</param>
        /// <param name="ownerPhone">string value</param>
        /// <param name="wheelManufacturerName">string value</param>
        /// <returns></returns>
        public static Motorcycle CreateNewMotorcycle(float currentAmount,E_EngineType engineType, E_LicenseType licenseType, int engineVolume,
            string vehicleModel,string vehicleLicensePlate, string ownerName, string ownerPhone, string wheelManufacturerName)
        {
            ///create a new show of engine for Motorcycle
            Engine engine;
            ///switch statment to choose between two types of engine (Fuel/Electric) or invalid value exception in case of unknown value. 
            switch (engineType)
            {
                case E_EngineType.Fuel:
                    engine = EngineFactory.CreateNewEngine(1.6f, currentAmount);
                    break;
                case E_EngineType.Electric:
                    engine = EngineFactory.CreateNewEngine(E_FuelType.Octan95, 5.5f, currentAmount);
                    break;
                default:
                    throw new ArgumentException("Invalid Type");
            }
            ///create the Motorcycle object itself.
            Motorcycle motorcycle = new Motorcycle(licenseType, engineVolume,
                E_VehicleType.Bike, vehicleModel, vehicleLicensePlate, ownerName, ownerPhone,
                E_VehicleStateInGarage.InWork, wheelManufacturerName, engine);
            return motorcycle;
        }
        /// <summary>
        /// Template for a Car method. (same as car values besides the enum for doors)
        /// </summary>
        public static Car CreateNewCar(float currentAmount, E_EngineType engineType, E_Color color, E_NumOfDoors numOfDoors, string vehicleModel,
            string vehicleLicensePlate, string ownerName, string ownerPhone, string wheelManufacturerName)
        {
            Engine engine;
            ///switch statment to choose between two types of engine (Fuel/Electric) or invalid value exception in case of unknown value. 
            switch (engineType)
            {
                case E_EngineType.Fuel:
                    engine = EngineFactory.CreateNewEngine(E_FuelType.Octan98, 50.0f, currentAmount);
                    break;
                case E_EngineType.Electric:
                    engine = EngineFactory.CreateNewEngine(2.8f, currentAmount);
                    break;
                default:
                    throw new ArgumentException("Invalid Type");
            }
            ///create the Car object itself.
            Car car = new Car(color, numOfDoors, E_VehicleType.Car, vehicleModel, vehicleLicensePlate,
                ownerName, ownerPhone, E_VehicleStateInGarage.InWork, wheelManufacturerName, engine);
            return car;
        }
        /// <summary>
        /// Template for a Truck method. (same as car values besides the bool for hezedosmaterials carry)
        /// </summary>
        public static Truck CreateNewFuelTruck(float currentAmount, bool hezerdosMat, float maxWeight, string vehicleModel,
            string vehicleLicensePlate, string ownerName, string ownerPhone, string wheelManufacturerName)
        {
            ///creating a new "show" of engine Gasoline type using the Gasoline class.
            Engine engine = new Gasoline(E_FuelType.Soler, 130.0f, currentAmount);
            ///create the Truck object itself.
            Truck truck = new Truck(hezerdosMat, maxWeight,E_VehicleType.Truck, vehicleModel, vehicleLicensePlate,
                ownerName, ownerPhone, E_VehicleStateInGarage.InWork, wheelManufacturerName, engine);
            return truck;
        }

    }
}
