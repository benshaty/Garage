using System;

namespace Garage.GarageLogic
{
    public static class VehicleFactory
    {
        public static Motorcycle CreateNewMotorcycle(float currentAmount,E_EngineType engineType, E_LicenseType licenseType, int engineVolume,
            string vehicleModel,string vehicleLicensePlate, string ownerName, string ownerPhone, string wheelManufacturerName)
        {
            Engine engine;
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
            Motorcycle motorcycle = new Motorcycle(licenseType, engineVolume,
                E_VehicleType.Bike, vehicleModel, vehicleLicensePlate, ownerName, ownerPhone,
                E_VehicleStateInGarage.InWork, wheelManufacturerName, engine);
            return motorcycle;
        }
        public static Car CreateNewCar(float currentAmount, E_EngineType engineType, E_Color color, E_NumOfDoors numOfDoors, string vehicleModel,
            string vehicleLicensePlate, string ownerName, string ownerPhone, string wheelManufacturerName)
        {
            Engine engine;
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
            Car car = new Car(color, numOfDoors, E_VehicleType.Car, vehicleModel, vehicleLicensePlate,
                ownerName, ownerPhone, E_VehicleStateInGarage.InWork, wheelManufacturerName, engine);
            return car;
        }
        public static Truck CreateNewFuelTruck(float currentAmount, bool hezerdosMat, float maxWeight, string vehicleModel,
            string vehicleLicensePlate, string ownerName, string ownerPhone, string wheelManufacturerName)
        {
            Engine engine = new Gasoline(E_FuelType.Soler, 130.0f, currentAmount);
            Truck truck = new Truck(hezerdosMat, maxWeight,E_VehicleType.Truck, vehicleModel, vehicleLicensePlate,
                ownerName, ownerPhone, E_VehicleStateInGarage.InWork, wheelManufacturerName, engine);
            return truck;
        }

    }
}
