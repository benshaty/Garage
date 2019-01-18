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
    public static class EngineFactory
    {
        public static Engine CreateNewEngine (E_FuelType fuelType,float maxAmount, float currentAmount)
        {
            return new Gasoline(fuelType,maxAmount,currentAmount);
        }
        public static Engine CreateNewEngine(float maxAmount, float currentAmount)
        {
            return new Electric(maxAmount,currentAmount);
        }
    }
}
