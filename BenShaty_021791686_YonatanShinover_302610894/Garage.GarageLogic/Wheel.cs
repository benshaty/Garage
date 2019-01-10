using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// The wheel Class
    /// </summary>
   public class Wheel
    {
        /// <summary>
        /// The manufacturer wheel name
        /// </summary>
        public string ManufacturerName { get; set; }
        /// <summary>
        /// The current air presure in the wheel
        /// </summary>
        public float WheelAirPresure { get; set; }
        /// <summary>
        /// The maximum amount of the wheel air presure
        /// </summary>
        public float MaxAirPresure { get; set; }
        /// <summary>
        /// add air to wheel only if not over the maximum air pressure 
        /// </summary>
        /// <param name="airToAdd">ammount of air to add to the wheel</param>
        public void AddAirToWheel(float airToAdd)
        {
            if (WheelAirPresure + airToAdd <= MaxAirPresure)
            {
                WheelAirPresure += airToAdd;
            } else
            {
                throw new ValueOutOfRangeException("Select less amount", MaxAirPresure, 0, (WheelAirPresure + airToAdd));
            }
        } 
        /// <summary>
        /// Create A new Wheel Obj
        /// </summary>
        /// <param name="manuName">the manufacturer name</param>
        /// <param name="maxAirPresure">wheel max air presure</param>
        public Wheel(string manuName, float maxAirPresure)
        {
            MaxAirPresure = WheelAirPresure = maxAirPresure;
            ManufacturerName = manuName;
        }
    }
}
