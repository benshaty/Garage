using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is the Car Class inheriting from Vehicle
    /// </summary>
    class Car : Vehicle
    {
        /// <summary>
        /// This is the Color of the Car
        /// </summary>
        public E_Color Color { get; set; }
        /// <summary>
        /// This is the Doors number of a Car
        /// </summary>
        public E_NumOfDoors Doors { get; set; }
    }
}
