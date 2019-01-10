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
        public Engine createNewEngine (E_EngineType engineType)
        {
            return engineType;
        }
    }
}
