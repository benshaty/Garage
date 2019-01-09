using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
   public class Wheel
    {
        public string ManufacturerName { get; set; }
        public float WheelAirPresure { get; set; }
        /// <summary>
        /// add air to wheel only if not over the maximum air pressure 
        /// </summary>
        /// <param name="airToAdd">ammount of air to add to the wheel</param>
        public void AddAirToWheel(float airToAdd)
        {
            
        }
    }
}
