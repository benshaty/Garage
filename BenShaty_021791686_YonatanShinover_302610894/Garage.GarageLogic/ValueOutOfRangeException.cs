using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is an Exception for Out Of Range Class
    /// </summary>
    public class ValueOutOfRangeException : Exception
    {
        private float MaxValue;
        private float MinValue;
        public string CustomMessage { get; set; }
        public ValueOutOfRangeException()
        {

        }
        public ValueOutOfRangeException(string message) : base(message)
        {

        }
        public ValueOutOfRangeException(string message, float maxValue, float minValue, float userValue) : base(message)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            CustomMessage = checkErr(MaxValue,MinValue,userValue);
        }
        /// <summary>
        /// Check what kind or error user get
        /// </summary>
        /// <param name="max">max value</param>
        /// <param name="min">min value</param>
        /// <param name="userValue">user input</param>
        /// <returns></returns>
        private string checkErr(float max, float min , float userValue)
        {
            string returnData = "";
            if (userValue > max)
            {
                returnData = "Value is Bigger then Max";
            } else if (min > userValue)
            {
                returnData = "Value is Smaller the Min";
            }
            return returnData;
        }
    }
}
