using Garage.GarageLogic;
using System;
using System.Collections.Generic;
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
            showmenu();
            Console.WriteLine("Have a good one!!!");
        }


        private static void showmenu()
        {
            Console.WriteLine("=============================================");
            foreach (var item in Enum.GetValues(typeof(E_FirstMenu)))
            {
                Console.WriteLine($"{(int) item} - {item.ToString().Replace("_"," ")}");
            }
            actionForFirstMenu(getFirstMenuResponse());
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
        private static void actionForFirstMenu(E_FirstMenu e_FirstMenu)
        {
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
                    break;
            }
        }


        private static void addEnergyToVhicle()
        {
            throw new NotImplementedException();
        }

        private static void showVehicleFullDetails()
        {
            throw new NotImplementedException();
        }

        private static void addAirToVehileWheels()
        {
            throw new NotImplementedException();
        }

        private static void addAVehicle()
        {
            Console.WriteLine("add a vehicle");
        }

        private static void changeCarState()
        {
            Console.WriteLine("Enter VehicleLicensePlate");
            string licensePlate = Console.ReadLine();
            E_VehicleStateInGarage vehicleState = getVehicleStateFromUser();
            try
            {
                Vehicle vehicle = GarageLogic.GarageLogic.GetVehicleByLicensePlate(licensePlate);
                GarageLogic.GarageLogic.ChangeVehicleStateInGarage(vehicle, vehicleState);
                Console.WriteLine($"{vehicle.VehicleType} changed status to {vehicle.VehicleStateInGarage}");
                showmenu();
            }
            catch (Exception)
            {

                Console.WriteLine("Vehicle is not in garage");
                Console.WriteLine("Do you want to put vehicle in the garage?");
                string answer = Console.ReadLine();
                if (answer.StartsWith("y") || answer.StartsWith("Y"))
                {
                    addAVehicle();
                }
                else
                {
                    showmenu();
                }
            }
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
                getFirstMenuResponse();
            }
            return userResponse;
        }
    }
}
