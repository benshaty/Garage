using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is the Truck Class inheriting from Vehicle
    /// </summary>
    class Truck : Vehicle
    {
        /// <summary>
        /// This is the True/False Hazardous materials status of the Truck 
        /// </summary>
        public bool HazardousMaterials { get; set; }
        /// <summary>
        /// This is the Max weight amount a Truck can lift
        /// </summary>
        public float MaxWeight { get; set; }

    }
}
