﻿using System;
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
        /// <summary>
        /// The Dictionary method. create the dictionary object
        /// </summary>
        public static Dictionary<string, Vehicle> GarageDirectory = new Dictionary<string, Vehicle>();
        /// <summary>
        /// Method to change the state of vehicle in the garage.
        /// </summary>
        /// <param name="vehicleToChange">inserting vehicleToChange attribute value</param>
        /// <param name="VehicleStateInGarage">enum value</param>
        public static void ChangeVehicleStateInGarage(Vehicle vehicleToChange, E_VehicleStateInGarage VehicleStateInGarage)
        {
            vehicleToChange.VehicleStateInGarage = VehicleStateInGarage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleToChange"></param>
        public static void AddAirToVehicleWheelsToMax(Vehicle vehicleToChange)
        {
            vehicleToChange.VehicleWheels.AddAirToMax();
        }
        public static Vehicle GetVehicleByLicensePlate(string licensePlate)
        {
            Vehicle vehicleToReturn;
            if (!GarageDirectory.ContainsKey(licensePlate))
            {
                throw new KeyNotFoundException("Vehicle not present!");
            }
            GarageDirectory.TryGetValue(licensePlate, out vehicleToReturn);
            return vehicleToReturn;
        }

        public static void AddSampleGarageData()
        {
            Vehicle sample = (Vehicle)VehicleFactory.CreateNewCar(30.0f, E_EngineType.Fuel, E_Color.White, E_NumOfDoors.Five, "Toyota Acura", "BenTheKing", "Ben shaty", "0541111111", "Tesla");
            GarageDirectory.Add("BenTheKing", sample);
            sample = (Vehicle)VehicleFactory.CreateNewCar(26.0f, E_EngineType.Fuel, E_Color.White, E_NumOfDoors.Four, "Toyota Corola", "YonatanTheKing", "Yonatan shinover", "0521111111", "Tislam");
            GarageDirectory.Add("YonatanTheKing", sample);



        }
    }
}
