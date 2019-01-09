using System;

namespace Utils
{
    /// <summary>
    /// This is a class that contain all kind of utils we 
    /// need for the project
    /// TODO: make it a good Dll for future use
    /// </summary>
    public static class Parsers
    {
        public static int GetIntFromUser(string message)
        {
            bool res;
            int returnNumber;
            do
            {
                Console.WriteLine(message);
                res = int.TryParse(Console.ReadLine(), out returnNumber);
            } while (!res);
            return returnNumber;
        }
        public static double GetDoubleFromUser(string message)
        {
            bool res;
            double returnNumber;
            do
            {
                Console.WriteLine(message);
                res = double.TryParse(Console.ReadLine(), out returnNumber);
            } while (!res);
            return returnNumber;
        }
    }
}
