using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float MaxValue;
        private float MinValue;
        public string CustomMassege { get; set; }
        public ValueOutOfRangeException()
        {

        }
        public ValueOutOfRangeException(string massage) : base(massage)
        {

        }
        public ValueOutOfRangeException(string massage, float maxValue, float minValue, float userValue) : base(massage)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            CustomMassege = checkErr(MaxValue,MinValue,userValue);
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
