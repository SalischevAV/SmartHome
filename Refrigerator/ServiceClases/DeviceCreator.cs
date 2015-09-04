using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refrigerator
{
    public class DeviceCreator
    {
        public string TypeOfDevice { set; get; }
        public Device NewDevice { set; get; }

        public Device CreateDevice(string TypeOfDevice)
        {
            switch (TypeOfDevice)
            {
                case ("refrigerator"):
                    NewDevice = new Refrigerator();
                    NewDevice.deviceNotificator +=  ServiceMessages.Message;
                    return NewDevice;
                case ("conditioner"):
                    NewDevice = new Conditioner();
                    return NewDevice;
                case ("radio"):
                default:
                    NewDevice = new Radio();
                    return NewDevice;
                
                   

            }
        }
    }
}
