using Garage.GarageLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Garage.GarageUI
{
    public static class GarageApp
    {
        /// <summary>
        /// main method of the GarageApp class
        /// </summary>
        public static void StartApp()
        {
            ///inserting a new vehicle type to the system by default by creating a new "show" of vehicle object using the vehicle class. 
            Vehicle x = (Vehicle) VehicleFactory.CreateNewFuelTruck(70f,true, 33, "model", "licecnseplate", "cdcdscs", "cdscdsc", "cdcdscds");
            GarageLogic.GarageLogic.GarageDirectory.Add("sss", x);
            Console.WriteLine("Welcome to our garage");
            Console.WriteLine("This project made by: Ben Shaty and Yonatan Shinover");
            Console.WriteLine("Enjoy using the system");
            bool continueFlag = true;
            ///loop to show menu until pressing exit
            do
            {
                continueFlag = showmenu();
            } while (continueFlag);
            Console.WriteLine("Have a good one!!!");
        }

        /// <summary>
        /// private method for replacing "_" with spaces in the menu text.
        /// </summary>
        /// <returns></returns>
        private static bool showmenu()
        {
            ///replacing "_" with spaces
            Console.WriteLine("=============================================");
            foreach (var item in Enum.GetValues(typeof(E_FirstMenu)))
            {
                Console.WriteLine($"{(int) item} - {item.ToString().Replace("_"," ")}");
            }
            ///calling for getFirstMenuResponse() method
            return (actionForFirstMenu(getFirstMenuResponse()));
        }
        /// <summary>
        /// The getFirstMenuResponse method
        /// </summary>
        /// <returns></returns>
        private static E_FirstMenu getFirstMenuResponse()
        {
            ///create a new show and Entering a value from user and repeat menu if invalid after printing a message.
            E_FirstMenu userResponse = E_FirstMenu.Exit_system;
            try
            {
                userResponse = Utils.Parsers.ParseFirstMenu("Enter menu item:");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                userResponse = Utils.Parsers.ParseFirstMenu("Enter menu item:");
            }
            return userResponse;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e_FirstMenu"></param>
        /// <returns></returns>
        private static bool actionForFirstMenu(E_FirstMenu e_FirstMenu)
        {
            Console.WriteLine("=============================================");
            bool result = true;
            switch (e_FirstMenu)
            {
                case E_FirstMenu.Exit_system:
                    result = false;
                    break;
                case E_FirstMenu.Add_a_vehicle:
                    ///calling adding a vehicle method 
                    addAVehicle();
                    break;
                case E_FirstMenu.Show_vehicles_by_license_plate:
                    ///calling showCarsByLicencePlate method
                    showCarsByLicencePlate();
                    break;
                case E_FirstMenu.Show_vehicles_by_license_plate_with_filter:
                    ///calling showCarsByLicencePlateWithFilter method
                    showCarsByLicencePlateWithFilter();
                    break;
                case E_FirstMenu.Change_car_state:
                    ///calling changeCarState method
                    changeCarState();
                    break;
                case E_FirstMenu.Add_air_to_vehicle_wheels:
                    ///calling addAirToVehileWheels method
                    addAirToVehileWheels();
                    break;
                case E_FirstMenu.Add_energy_to_vehicle:
                    ///calling addEnergyToVhicle method
                    addEnergyToVhicle();
                    break;
                case E_FirstMenu.Show_vehicle_full_details:
                    ///calling showVehicleFullDetails method
                    showVehicleFullDetails();
                    break;
                case E_FirstMenu.Clear_the_screen:
                    ///clear the screen
                    Console.Clear();
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }
        /// <summary>
        /// The add vehicle method
        /// </summary>
        private static void addAVehicle()
        {
            E_VehicleType vehicleType;
            try
            {
                vehicleType = Utils.Parsers.ParseVehicleType();
                E_EngineType engineType;
                switch (vehicleType)
                {
                    case E_VehicleType.Bike:
                        engineType = getEngineType();
                        addNewBike(engineType);
                        break;
                    case E_VehicleType.Car:
                        engineType = getEngineType();
                        addNewCar(engineType);
                        break;
                    case E_VehicleType.Truck:
                        addNewTruck();
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message + "Can`t parse vehicle type");
            }
        }

        private static E_EngineType getEngineType()
        {
            E_EngineType engineType;
            try
            {
                engineType = Utils.Parsers.ParseEngineType();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message + "can`t parse engine type");
                engineType = Utils.Parsers.ParseEngineType();
            }
            return engineType;
        }

        private static void addNewTruck()
        {
            try
            {
                bool hezerdosMat = false;
                Console.WriteLine("the truck carry hezerdos matirials? (yes or no)");
                string answer = Console.ReadLine();
                if (answer.StartsWith("y") || answer.StartsWith("Y"))
                {
                    hezerdosMat = true;
                } else
                {
                    hezerdosMat = false;
                }
                float maxWeight = Utils.Parsers.GetFloatFromUser("Enter truck max weight:");
                float currentAmount;
                string vehicleModel;
                string vehicleLicensePlate;
                string ownerName;
                string ownerPhone;
                string wheelManufacturerName;
                Utils.Parsers.RefBasicVehicleDetails(out currentAmount, out vehicleModel, out vehicleLicensePlate,
                    out ownerName, out ownerPhone, out wheelManufacturerName);
                GarageLogic.GarageLogic.GarageDirectory.Add(vehicleLicensePlate, VehicleFactory.CreateNewFuelTruck(currentAmount, hezerdosMat,
                    maxWeight, vehicleModel, vehicleLicensePlate, ownerName, ownerPhone, wheelManufacturerName));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message + "Can`t parse Truck!");
            }

        }
        
        private static void addNewCar(E_EngineType engineType)
        {
            try
            {
                E_Color color = Utils.Parsers.ParseCarColor();
                E_NumOfDoors numOfDoors = Utils.Parsers.ParseNumOfCarDoors();
                float currentAmount;
                string vehicleModel;
                string vehicleLicensePlate;
                string ownerName;
                string ownerPhone;
                string wheelManufacturerName;
                Utils.Parsers.RefBasicVehicleDetails(out currentAmount, out vehicleModel, out vehicleLicensePlate, 
                    out ownerName, out ownerPhone,out wheelManufacturerName);
                GarageLogic.GarageLogic.GarageDirectory.Add(vehicleLicensePlate, VehicleFactory.CreateNewCar
                    (currentAmount,engineType, color, numOfDoors, vehicleModel, vehicleLicensePlate, ownerName, ownerPhone, wheelManufacturerName));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message + "Can`t parse Car!");
            }
        }

        private static void addNewBike(E_EngineType engineType)
        {
            try
            {
                E_LicenseType licenseType = Utils.Parsers.ParseLicenseType();
                int engineVolume = Utils.Parsers.GetIntFromUser("Enter engine volume in cc:");
                float currentAmount;
                string vehicleModel;
                string licensePlate;
                string ownerName;
                string ownerPhone;
                string wheelManufacturerName;
                Utils.Parsers.RefBasicVehicleDetails(out currentAmount, out vehicleModel, out licensePlate,
                    out ownerName, out ownerPhone, out wheelManufacturerName);
                GarageLogic.GarageLogic.GarageDirectory.Add(licensePlate, VehicleFactory.CreateNewMotorcycle(currentAmount,engineType, 
                    licenseType, engineVolume, vehicleModel, licensePlate, ownerName, ownerPhone, wheelManufacturerName));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message + "Can`t parse Motorcycle!");
            }

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
                    vehicle.VehicleWheels.AddAirToWheel(airToAdd);
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
                Console.WriteLine($"License plate {item.Key}:");
                Console.WriteLine("=============================================");
                Console.WriteLine(item.Value.ToString());
            }
        }
        private static void showCarsByLicencePlate(E_VehicleStateInGarage state)
        {
            foreach (var item in GarageLogic.GarageLogic.GarageDirectory)
            {
                if (item.Value.VehicleStateInGarage == state)
                    Console.WriteLine($"License plate {item.Key}:");
                    Console.WriteLine("=============================================");
                    Console.WriteLine(item.Value.ToString());

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
