using System.Collections.Generic;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is the garage Logic main class
    /// </summary>
    /*
    + AddNewVehicleToGarage (string LicensePlate) <vehicle> 
    + ChangeCarStateInGarage (string LicensePlate , E_CarStateInGarage CarStateInGarage) <void> 
    + AddAirToVehicleWheelsToMax (string LicensePlate) <void>
    */
    public static class GarageLogic
    {
        public static Dictionary<string, Vehicle> GarageDirectory { get; set; }
        public static void ChangeVehicleStateInGarage(Vehicle vehicleToChange, E_VehicleStateInGarage VehicleStateInGarage)
        {
            vehicleToChange.VehicleStateInGarage = VehicleStateInGarage;
        }
        public static void AddAirToVehicleWheelsToMax(Vehicle vehicleToChange)
        {
            foreach (var wheel in vehicleToChange.VehicleWheels)
            {
                wheel.AddAirToMax();
            }
        }

    }
}
