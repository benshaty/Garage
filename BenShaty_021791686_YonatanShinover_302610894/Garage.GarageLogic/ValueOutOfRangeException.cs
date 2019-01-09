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
        public ValueOutOfRangeException(string massage, float maxValue, float minValue, float value) : base(massage)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            CustomMassege = checkErr(MaxValue,MinValue,value);
        }
        private string checkErr(float max, float min , float value)
        {
            string returnData = "";
            if (value > max)
            {
                returnData = "Value is Bigger then Max";
            } else if (min > value)
            {
                returnData = "Value is Smaller the Min";
            }
            return returnData;
        }
    }
}
