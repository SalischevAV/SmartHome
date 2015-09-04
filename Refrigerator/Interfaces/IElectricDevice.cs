using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refrigerator
{
    public interface IElectricDevice
    {
        void InclusionShutdown(bool PowerOn);
    }
}
