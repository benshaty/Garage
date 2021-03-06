﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is the Engine Class
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// This is the Engine type of a Vehicle
        /// </summary>
        public E_EngineType EngineType { get; set; }
        public float CurrentAmount { get; set; }
        /// <summary>
        /// Add energy to an Electric Vehicle
        /// </summary>
        /// <param name="ElectricAmount">Electric Amount to Add (float)</param>
        public virtual void AddEnergy(float electricAmount)
        {
            throw new ArgumentException("This is an Gasoline Vehicle");
        }
        /// <summary>
        /// Add energy to an Gasoline Vehicle
        /// </summary>
        /// <param name="GasolineAmount">amount of gasoline to add</param>
        /// <param name="FuelType">fuel type Enum</param>
        public virtual void AddEnergy(float GasolineAmount, E_FuelType FuelType)
        {
            throw new ArgumentException("This is an Electric Vehicle");
        }
    }
}
