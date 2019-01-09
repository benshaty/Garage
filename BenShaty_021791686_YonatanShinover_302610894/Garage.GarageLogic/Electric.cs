using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    class Electric : Engine
    {
        public float CurrentAmount { get; set; }
        public float MaxAmount { get; set; }
        /// <summary>
        /// Constractor for Electric type Engine
        /// </summary>
        /// <param name="maxAmount">max amount of fuel can be</param>
        public Electric(float maxAmount)
        {
            CurrentAmount = maxAmount;
            MaxAmount = maxAmount;
        }
        /// <summary>
        /// Add energy to an Electric Vehicle
        /// </summary>
        /// <param name="ElectricAmount">Electric Amount to Add (float)</param>
        public override void AddEnergy(float electricAmount)
        {
            if ((CurrentAmount + electricAmount) <= MaxAmount)
            {
                CurrentAmount += electricAmount;
            }
            else
            {
                throw new ValueOutOfRangeException("Select less amount", MaxAmount, 0, (CurrentAmount + electricAmount));
            }
        }
    }
}
