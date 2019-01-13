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
        }

        private static void showmenu()
        {
            Console.WriteLine("=============================================");
            foreach (var item in Enum.GetValues(typeof(E_FirstMenu)))
            {
                Console.WriteLine($"{(int) item} - {item.ToString().Replace("_"," ")}");
            }
            Console.Write("Enter menu item:");
        }
    }
}
