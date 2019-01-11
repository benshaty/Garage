using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    /// <summary>
    /// This is the Engine Factory sealed Class
    /// </summary>
    sealed class EngineFactory
    {
        public Engine CreateNewEngine (E_FuelType fuelType,float maxAmount)
        {
            return new Gasoline(fuelType,maxAmount);
        }
        public Engine CreateNewEngine(float maxAmount)
        {
            return new Electric(maxAmount);
        }
    }
}
