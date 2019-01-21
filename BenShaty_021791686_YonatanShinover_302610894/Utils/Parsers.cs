using System;
using Garage.GarageLogic;

namespace Utils
{
    /// <summary>
    /// This is a class that contain all kind of utils we 
    /// need for the project
    /// TODO: make it a good Dll for future use
    /// </summary>
    public static class Parsers
    {
        /// <summary>
        /// parse the first menu enum from string
        /// </summary>
        /// <param name="massege">getting a string value</param>
        /// <returns></returns>
        public static E_FirstMenu ParseFirstMenu(string massege)
        {
            E_FirstMenu result;
            do
            {

            int intTempResualt = GetIntFromUser(massege);
                switch ((E_FirstMenu)intTempResualt)
                {
                    case E_FirstMenu.Exit_system:
                    case E_FirstMenu.Add_a_vehicle:
                    case E_FirstMenu.Show_vehicles_by_license_plate:
                    case E_FirstMenu.Show_vehicles_by_license_plate_with_filter:
                    case E_FirstMenu.Change_car_state:
                    case E_FirstMenu.Add_air_to_vehicle_wheels:
                    case E_FirstMenu.Add_energy_to_vehicle:
                    case E_FirstMenu.Show_vehicle_full_details:
                    case E_FirstMenu.Clear_the_screen:
                        result = (E_FirstMenu)intTempResualt;
                        break;
                    default:
                        throw new FormatException("Invalid selection");
                }
            } while (!Enum.IsDefined(typeof(E_FirstMenu), result));
            return result;
        }
        /// <summary>
        /// Get and Parse user input from console to int
        /// </summary>
        /// <param name="message">massege to show to the user</param>
        /// <returns>number after parsing</returns>
        public static int GetIntFromUser(string message)
        {
            bool res;
            int returnNumber = 0;
            do
            {
                try
                {

                    Console.WriteLine(message);
                    returnNumber = parseInt(Console.ReadLine());
                    res = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                }
            } while (!res);
            return returnNumber;
        }
        
        /// <summary>
        /// Get and Parse user input from console to double
        /// </summary>
        /// <param name="message">massege to show to the user</param>
        /// <returns>number after parsing</returns>
        public static double GetDoubleFromUser(string message)
        {
            bool res;
            double returnNumber = 0;
            do
            {
                try
                {

                    Console.WriteLine(message);
                    returnNumber = parseDouble(Console.ReadLine());
                    res = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                }
            } while (!res);
            return returnNumber;
        }
        
        /// <summary>
        /// Get and Parse user input from console to float
        /// </summary>
        /// <param name="message">massege to show to the user</param>
        /// <returns>number after parsing</returns>
        public static float GetFloatFromUser(string message)
        {
            bool res;
            float returnNumber = 0;
            do
            {
                try
                {

                    Console.WriteLine(message);
                    returnNumber = parseFloat(Console.ReadLine());
                    res = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                }
            } while (!res);
            return returnNumber;
        }
        /// <summary>
        /// Getting the fuel type from user method
        /// </summary>
        /// <returns></returns>
        public static E_FuelType getFuelTypeFromUser()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// parse from string to int
        /// </summary>
        /// <param name="dataToParse"></param>
        /// <returns></returns>
        private static int parseInt(string dataToParse)
        {
            try
            {
                int returnNumber;
                returnNumber = int.Parse(dataToParse);
                return returnNumber;
            }
            catch (FormatException ex)
            {

                throw new FormatException("Invalid Value", ex);
            }
        }
        /// <summary>
        /// parse the state in garage enum
        /// </summary>
        /// <returns></returns>
        public static E_VehicleStateInGarage ParseStateInGarage()
        {
            E_VehicleStateInGarage result;
            do
            {
                foreach (var item in Enum.GetValues(typeof(E_VehicleStateInGarage)))
                {
                    if ((int)item > 0)
                    {
                        Console.WriteLine($"{(int)item} - {item}");
                    }
                }
                ///switch the value entered by user
                int intTempResualt = GetIntFromUser("Select Vehicle state");
                switch ((E_VehicleStateInGarage)intTempResualt)
                {
                    case E_VehicleStateInGarage.NotInGarage:
                    case E_VehicleStateInGarage.InWork:
                    case E_VehicleStateInGarage.Ready:
                    case E_VehicleStateInGarage.Paid:
                        result = (E_VehicleStateInGarage)intTempResualt;
                        break;
                    default:
                        throw new FormatException("Invalid selection");
                }
            } while (!Enum.IsDefined(typeof(E_VehicleStateInGarage), result));
            return result;
        }
        /// <summary>
        /// parse string to double
        /// </summary>
        /// <param name="dataToParse"></param>
        /// <returns></returns>
        private static double parseDouble(string dataToParse)
        {
            try
            {
                double returnNumber;
                returnNumber = double.Parse(dataToParse);
                return returnNumber;
            }
            catch (FormatException ex)
            {

                throw new FormatException("Invalid Value", ex);
            }
        }
        /// <summary>
        /// parse the string to float.
        /// </summary>
        /// <param name="dataToParse"></param>
        /// <returns></returns>
        private static float parseFloat(string dataToParse)
        {
            try
            {
                float returnNumber;
                returnNumber = float.Parse(dataToParse);
                return returnNumber;
            }
            catch (FormatException ex)
            {

                throw new FormatException("Invalid Value", ex);
            }
        }
        /// <summary>
        /// transfer the vehicle details by reference using (the out key) method 
        /// </summary>
        /// <param name="currentAmount"></param>
        /// <param name="vehicleModel"></param>
        /// <param name="vehicleLicensePlate"></param>
        /// <param name="ownerName"></param>
        /// <param name="ownerPhone"></param>
        /// <param name="wheelManufacturerName"></param>
        public static void RefBasicVehicleDetails(out float currentAmount, out string vehicleModel,
            out string vehicleLicensePlate, out string ownerName, out string ownerPhone, out string wheelManufacturerName)
        {
            Console.Write("Enter model:");
            vehicleModel = Console.ReadLine();
            Console.WriteLine("Enter licence plate:");
            vehicleLicensePlate = Console.ReadLine();
            Console.WriteLine("Enter owner name:");
            ownerName = Console.ReadLine();
            Console.WriteLine("Enter owner phone:");
            ownerPhone = Console.ReadLine();
            Console.WriteLine("Enter wheels manufacturer name:");
            wheelManufacturerName = Console.ReadLine();
            currentAmount = Utils.Parsers.GetIntFromUser("Enter current amount");
        }

        /// <summary>
        /// parse the vehicle type enum
        /// </summary>
        /// <returns></returns>
        public static E_VehicleType ParseVehicleType()
        {
            E_VehicleType result;
            do
            {
                foreach (var item in Enum.GetValues(typeof(E_VehicleType)))
                {
                    Console.WriteLine($"{(int)item} - {item}");
                }
                int intTempResualt = GetIntFromUser("Select Vehicle type");
                switch ((E_VehicleType)intTempResualt)
                {
                    case E_VehicleType.Bike:
                    case E_VehicleType.Car:
                    case E_VehicleType.Truck:
                        result = (E_VehicleType)intTempResualt;
                        break;
                    default:
                        throw new FormatException("Invalid selection");
                }
            } while (!Enum.IsDefined(typeof(E_VehicleType), result));
            return result;
        }
        /// <summary>
        /// parse the engine type enum
        /// </summary>
        /// <returns></returns>
        public static E_EngineType ParseEngineType()
        {
            E_EngineType result;
            do
            {
                foreach (var item in Enum.GetValues(typeof(E_EngineType)))
                {
                    Console.WriteLine($"{(int)item} - {item}");
                }
                int intTempResualt = GetIntFromUser("Select engine type");
                switch ((E_EngineType)intTempResualt)
                {
                    case E_EngineType.Fuel:
                    case E_EngineType.Electric:
                        result = (E_EngineType)intTempResualt;
                        break;
                    default:
                        throw new FormatException("Invalid selection");
                }
            } while (!Enum.IsDefined(typeof(E_EngineType), result));
            return result;
        }
        public static E_Color ParseCarColor()
        {
            E_Color result;
            do
            {
                foreach (var item in Enum.GetValues(typeof(E_Color)))
                {
                    Console.WriteLine($"{(int)item} - {item}");
                }
                int intTempResualt = GetIntFromUser("Select car color");
                switch ((E_Color)intTempResualt)
                {
                    case E_Color.Green:
                    case E_Color.Silver:
                    case E_Color.White:
                    case E_Color.Black:
                        result = (E_Color)intTempResualt;
                        break;
                    default:
                        throw new FormatException("Invalid selection");
            }
            } while (!Enum.IsDefined(typeof(E_Color), result));
            return result;
        }
        /// <summary>
        /// parse the num of doors enum
        /// </summary>
        /// <returns></returns>
        public static E_NumOfDoors ParseNumOfCarDoors()
        {
            E_NumOfDoors result;
            do
            {
                foreach (var item in Enum.GetValues(typeof(E_NumOfDoors)))
                {
                    Console.WriteLine($"{(int)item} - {item}");
                }
                int intTempResualt = GetIntFromUser("Select num of doors");
                switch ((E_NumOfDoors)intTempResualt)
                {
                    case E_NumOfDoors.Two:
                    case E_NumOfDoors.Three:
                    case E_NumOfDoors.Four:
                    case E_NumOfDoors.Five:
                        result = (E_NumOfDoors)intTempResualt;
                        break;
                    default:
                        throw new FormatException("Invalid selection");
            }
            } while (!Enum.IsDefined(typeof(E_NumOfDoors), result));
            return result;
        }
        ///Parse the license type enum
        public static E_LicenseType ParseLicenseType()
        {
            E_LicenseType result;
            do
            {
                foreach (var item in Enum.GetValues(typeof(E_LicenseType)))
                {
                    Console.WriteLine($"{(int)item} - {item}");
                }
                int intTempResualt = GetIntFromUser("Select license type");
                switch ((E_LicenseType)intTempResualt)
                {
                    case E_LicenseType.A1:
                    case E_LicenseType.B1:
                    case E_LicenseType.AA:
                    case E_LicenseType.BB:
                        result = (E_LicenseType)intTempResualt;
                        break;
                    default:
                        throw new FormatException("Invalid selection");
                }
            } while (!Enum.IsDefined(typeof(E_LicenseType), result));
            return result;
        }
    }
}
