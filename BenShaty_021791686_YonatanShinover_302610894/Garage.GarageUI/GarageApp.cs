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
            Console.WriteLine("Welcome to our garage");
            showmenu();
            actionForFirstMenu(getFirstMenuResponse());
            Console.WriteLine("Have a good one!!!");
        }


        private static void showmenu()
        {
            Console.WriteLine("=============================================");
            foreach (var item in Enum.GetValues(typeof(E_FirstMenu)))
            {
                Console.WriteLine($"{(int) item} - {item.ToString().Replace("_"," ")}");
            }
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
                    addEnergyTovVhicle();
                    break;
                case E_FirstMenu.Show_vehicle_full_details:
                    showVehicleFullDetails();
                    break;
                default:
                    break;
            }
        }

        private static void addEnergyTovVhicle()
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
            throw new NotImplementedException();
        }

        private static void changeCarState()
        {
            throw new NotImplementedException();
        }

        private static void showCarsByLicencePlateWithFilter()
        {
            throw new NotImplementedException();
        }

        private static void showCarsByLicencePlate()
        {
            throw new NotImplementedException();
        }
    }
}
