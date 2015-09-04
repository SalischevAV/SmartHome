using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refrigerator
{
    [Serializable]
    public abstract class Device: IElectricDevice
    {
        public bool PowerOn { set; get; }
        public virtual event Notificator deviceNotificator;
       

        public Device ()
        {
            PowerOn = false;
            
        }
        public virtual void InclusionShutdown(bool PowerOn)
        {
            this.PowerOn = PowerOn;
            
        }

        

        public override string ToString()
        {
         return base.ToString() + ", device condition: power - " + PowerOn.ToString() + " .";
        }
    }
}
