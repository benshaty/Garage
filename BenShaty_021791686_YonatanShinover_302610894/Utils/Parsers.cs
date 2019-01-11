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
                catch (Exception ex)
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
                catch (Exception ex)
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                }
            } while (!res);
            return returnNumber;
        }
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
        
    }
}
