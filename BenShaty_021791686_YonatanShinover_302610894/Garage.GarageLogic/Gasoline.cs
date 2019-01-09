using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    class Gasoline : Engine
    {
        public E_FuelType FuelType { get; set; }
        public float CurrentAmount { get; set; }
        public float MaxAmount { get; set; }
        /// <summary>
        /// Constractor for Gasoline type Engine
        /// </summary>
        /// <param name="fuelType">type of fuel for the vehicle</param>
        /// <param name="maxAmount">max amount of fuel can be</param>
        public Gasoline(E_FuelType fuelType, float maxAmount)
        {
            CurrentAmount = maxAmount;
            MaxAmount = maxAmount;
            FuelType = fuelType;

        }
        /// <summary>
        /// Add energy to an Gasoline Vehicle
        /// </summary>
        /// <param name="gasolineAmount">amount of gasoline to add</param>
        /// <param name="fuelType">fuel type Enum</param>
        public override void AddEnergy(float gasolineAmount, E_FuelType fuelType)
        {
            if ((CurrentAmount + gasolineAmount) <= MaxAmount)
            {
                CurrentAmount += gasolineAmount;
            } else
            {
                throw new ValueOutOfRangeException("Select less amount", MaxAmount, 0, (CurrentAmount + gasolineAmount));
            }
        }
    }
}
