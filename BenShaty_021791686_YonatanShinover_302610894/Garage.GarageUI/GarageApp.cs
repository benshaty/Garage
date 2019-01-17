using Garage.GarageLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageUI
{
    public static class GarageApp
    {
        public static void StartApp()
        {
            Vehicle x = (Vehicle) VehicleFactory.CreateNewFuelTruck(true, 33, "model", "licecnseplate", "cdcdscs", "cdscdsc", "cdcdscds");
            GarageLogic.GarageLogic.GarageDirectory.Add("sss", x);
            Console.WriteLine("Welcome to our garage");
            bool continueFlag = true;
            do
            {
                continueFlag = showmenu();
            } while (continueFlag);
            Console.WriteLine("Have a good one!!!");
        }


        private static bool showmenu()
        {
            Console.WriteLine("=============================================");
            foreach (var item in Enum.GetValues(typeof(E_FirstMenu)))
            {
                Console.WriteLine($"{(int) item} - {item.ToString().Replace("_"," ")}");
            }
            return (actionForFirstMenu(getFirstMenuResponse()));
        }
        private static E_FirstMenu getFirstMenuResponse()
        {
            E_FirstMenu userResponse = E_FirstMenu.Exit_system;
            try
            {
                userResponse = Utils.Parsers.ParseFirstMenu("Enter menu item:");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                getFirstMenuResponse();
            }
            return userResponse;
        }
        private static bool actionForFirstMenu(E_FirstMenu e_FirstMenu)
        {
            bool result = true;
            switch (e_FirstMenu)
            {
                case E_FirstMenu.Exit_system:
                    break;
                case E_FirstMenu.Add_a_vehicle:
                    addAVehicle();
                    break;
                case E_FirstMenu.Show_vehicles_by_license_plate:
                    showCarsByLicencePlate();
                    break;
                case E_FirstMenu.Show_vehicles_by_license_plate_with_filter:
                    showCarsByLicencePlateWithFilter();
                    break;
                case E_FirstMenu.Change_car_state:
                    changeCarState();
                    break;
                case E_FirstMenu.Add_air_to_vehicle_wheels:
                    addAirToVehileWheels();
                    break;
                case E_FirstMenu.Add_energy_to_vehicle:
                    addEnergyToVhicle();
                    break;
                case E_FirstMenu.Show_vehicle_full_details:
                    showVehicleFullDetails();
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }

        //TODO: fix addVehicle method
        private static void addAVehicle()
        {
            Console.WriteLine("add a vehicle");
        }

        private static void addEnergyToVhicle()
        {
            string licensePlate = getLicensePlateFromUser();
            try
            {
                Vehicle vehicle = GarageLogic.GarageLogic.GetVehicleByLicensePlate(licensePlate);
                try
                {
                    tryAddEnergy(vehicle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Vehicle is not in garage");
                Console.WriteLine("Do you want to put vehicle in the garage?");
                string answer = Console.ReadLine();
                if (answer.StartsWith("y") || answer.StartsWith("Y"))
                {
                    addAVehicle();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void tryAddEnergy(Vehicle vehicle)
        {
            switch (vehicle.VehicleEngine.EngineType)
            {
                case E_EngineType.Fuel:
                    E_FuelType fuelType = Utils.Parsers.getFuelTypeFromUser();
                    float amountToAdd = Utils.Parsers.GetFloatFromUser($"Enter amount of {fuelType} to add:");
                    try
                    {
                        vehicle.VehicleEngine.AddEnergy(amountToAdd, fuelType);
                        Console.WriteLine($"Added {amountToAdd} of type {fuelType} to the {vehicle.VehicleType}");
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        tryAddEnergy(vehicle);
                    }
                    break;
                case E_EngineType.Electric:
                    float timeToCharge = Utils.Parsers.GetFloatFromUser("Enter time amount to add");
                    try
                    {
                        vehicle.VehicleEngine.AddEnergy(timeToCharge);
                        Console.WriteLine($"Added {timeToCharge} to the {vehicle.VehicleType}");
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        tryAddEnergy(vehicle);
                    }
                    break;
                default:
                    throw new InvalidDataException("Unknown engine type");
            }
        }

        private static void showVehicleFullDetails()
        {
            string licensePlate = getLicensePlateFromUser();
            try
            {
                Vehicle vehicle = GarageLogic.GarageLogic.GetVehicleByLicensePlate(licensePlate);
                Console.WriteLine(vehicle.ToString());
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Vehicle is not in garage");
                Console.WriteLine("Do you want to put vehicle in the garage?");
                string answer = Console.ReadLine();
                if (answer.StartsWith("y") || answer.StartsWith("Y"))
                {
                    addAVehicle();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void addAirToVehileWheels()
        {

            string licensePlate = getLicensePlateFromUser();
            try
            {
                Vehicle vehicle = GarageLogic.GarageLogic.GetVehicleByLicensePlate(licensePlate);
                try
                {
                    float airToAdd = Utils.Parsers.GetFloatFromUser("Enter air amount to add to the wheels");
                    foreach (var item in vehicle.VehicleWheels)
                    {
                        item.AddAirToWheel(airToAdd);
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.CustomMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Vehicle is not in garage");
                Console.WriteLine("Do you want to put vehicle in the garage?");
                string answer = Console.ReadLine();
                if (answer.StartsWith("y") || answer.StartsWith("Y"))
                {
                    addAVehicle();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void changeCarState()
        {
            string licensePlate = getLicensePlateFromUser();
            E_VehicleStateInGarage vehicleState = getVehicleStateFromUser();
            try
            {
                Vehicle vehicle = GarageLogic.GarageLogic.GetVehicleByLicensePlate(licensePlate);
                GarageLogic.GarageLogic.ChangeVehicleStateInGarage(vehicle, vehicleState);
                Console.WriteLine($"{vehicle.VehicleType} changed status to {vehicle.VehicleStateInGarage}");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Vehicle is not in garage");
                Console.WriteLine("Do you want to put vehicle in the garage?");
                string answer = Console.ReadLine();
                if (answer.StartsWith("y") || answer.StartsWith("Y"))
                {
                    addAVehicle();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string getLicensePlateFromUser()
        {
            Console.WriteLine("Enter Vehicle License Plate");
            string result = Console.ReadLine();
            return result;
        }

        private static void showCarsByLicencePlateWithFilter()
        {
            showCarsByLicencePlate(getVehicleStateFromUser());  
        }
        private static void showCarsByLicencePlate()
        {
            foreach (var item in GarageLogic.GarageLogic.GarageDirectory)
            {
                Console.WriteLine(item.Key);
            }
        }
        private static void showCarsByLicencePlate(E_VehicleStateInGarage state)
        {
            foreach (var item in GarageLogic.GarageLogic.GarageDirectory)
            {
                if (item.Value.VehicleStateInGarage == state)
                    Console.WriteLine(item.Key);
            }
        }
        private static E_VehicleStateInGarage getVehicleStateFromUser()
        {
            E_VehicleStateInGarage userResponse = E_VehicleStateInGarage.NotInGarage;
            try
            {
                userResponse = Utils.Parsers.ParseStateInGarage();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                userResponse = Utils.Parsers.ParseStateInGarage();
            }
            return userResponse;
        }
    }
}
