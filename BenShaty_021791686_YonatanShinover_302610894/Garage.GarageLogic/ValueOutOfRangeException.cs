using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
    }
}
