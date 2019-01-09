using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// This is a class that contain all kind of utils we 
    /// need for the project
    /// TODO: make it a good Dll for future use
    /// </summary>
    public static class Parsers
    {
        public static int GetIntFromUser(string userInput)
        {
            bool res;
            int returnNumber;
            do
            {
                res = int.TryParse(userInput, out returnNumber);
            } while (res);
            return returnNumber;
        }
        public static double GetDoubleFromUser(string userInput)
        {
            bool res;
            double returnNumber;
            do
            {
                res = double.TryParse(userInput, out returnNumber);
            } while (res);
            return returnNumber;
        }

    }
}
