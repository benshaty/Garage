using System;

namespace Garage.GarageLogic
{
    public static class VehicleFactory
    {
        public static Motorcycle CreateNewMotorcycle(E_EngineType engineType, E_LicenseType licenseType, int engineVolume,
            string vehicleModel, string licencsePlate, string ownerName, string wheelManufacturerName, string OwnerPhone)
        {
            Engine engine;
            switch (engineType)
            {
                case E_EngineType.Fuel:
                    engine = new Electric(1.6f);
                    break;
                case E_EngineType.Electric:
                    engine = new Gasoline(E_FuelType.Octan95, 5.5f);
                    break;
                default:
                    throw new ArgumentException("Invalid Type");
            }
            Motorcycle motorcycle = new Motorcycle(licenseType, engineVolume,
                E_VehicleType.Bike, vehicleModel, licencsePlate, ownerName, OwnerPhone,
                E_VehicleStateInGarage.InWork, wheelManufacturerName, engine);
            return motorcycle;
        }
        public static Car CreateNewCar(E_EngineType engineType, E_Color color, E_NumOfDoors numOfDoors, string vehicleModel,
            string VehicleLicensePlate, string ownerName, string ownerPhone, string wheelManufacturerName)
        {
            Engine engine;
            switch (engineType)
            {
                case E_EngineType.Fuel:
                    engine = new Electric(2.8f);
                    break;
                case E_EngineType.Electric:
                    engine = new Gasoline(E_FuelType.Octan98, 50.0f);
                    break;
                default:
                    throw new ArgumentException("Invalid Type");
            }
            Car car = new Car(color, numOfDoors, E_VehicleType.Car, vehicleModel, VehicleLicensePlate,
                ownerName, ownerPhone, E_VehicleStateInGarage.InWork, wheelManufacturerName, engine);
            return car;
        }
        public static Truck CreateNewFuelTruck(bool hezerdosMat, float maxWeight, string vehicleModel,
            string VehicleLicensePlate, string ownerName, string ownerPhone, string wheelManufacturerName)
        {
            Engine engine = new Gasoline(E_FuelType.Soler, 130.0f);
            Truck truck = new Truck(hezerdosMat, maxWeight,E_VehicleType.Truck, vehicleModel, VehicleLicensePlate,
                ownerName, ownerPhone, E_VehicleStateInGarage.InWork, wheelManufacturerName, engine);
            return truck;
        }

    }
}
