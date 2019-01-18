using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is the Electric Engine type Class
    /// </summary>
    public class Electric : Engine
    {
        /// <summary>
        /// This is the Max amount Energy/Fuel in a Vehicle 
        /// </summary>
        public float MaxAmount { get; set; }
        /// <summary>
        /// Constractor for Electric type Engine
        /// </summary>
        /// <param name="maxAmount">max amount of fuel can be</param>
        /// <param name="currentAmount">current amount of energy</param>
        public Electric(float maxAmount, float currentAmount)
        {
            EngineType = E_EngineType.Electric;
            if (currentAmount > maxAmount)
            {
                CurrentAmount = maxAmount;
            } else
            {
                CurrentAmount = currentAmount;
            }
            MaxAmount = maxAmount;
        }
        /// <summary>
        /// Add energy to an Electric Vehicle function 
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
