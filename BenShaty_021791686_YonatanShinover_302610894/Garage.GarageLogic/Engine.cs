using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    public class Engine
    {
        /// <summary>
        /// Add energy to an Electric Vehicle
        /// </summary>
        /// <param name="LicensePlate">License Plate (string)</param>
        /// <param name="ElectricAmount">Electric Amount to Add (float)</param>
        public virtual void AddEnergy(string LicensePlate, float ElectricAmount)
        {

        }
        /// <summary>
        /// Add energy to an Gasoline Vehicle
        /// </summary>
        /// <param name="LicensePlate">License Plate (string)</param>
        /// <param name="GasolineAmount"></param>
        /// <param name="FuelType"></param>
        public virtual void AddEnergy(string LicensePlate, float GasolineAmount, E_FuelType FuelType)
        {

        }
    }
}
