using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refrigerator
{
    public class UIDevice
    {
        public string Message { set; get; }

       
        
        //----------------------------------------
        public void PowerDevice(IElectricDevice sameDevice)
        {
            Console.Write("Are you want switchOn or switchOff device? ");
            Message = (Console.ReadLine()).ToLower();
           

            if (Message.Contains("on"))
            {
                sameDevice.InclusionShutdown(true);
            }
            else if (Message.Contains("off"))
            {
                sameDevice.InclusionShutdown(false);
            }
            else
                Console.WriteLine("Set clear instructions!");
        }
        //------------------------------------------------------------------------
        public void DoorDevice(IDoorDevice sameDevice)
        {
            Console.Write("Are you want Open or Close device door? ");
            Message = (Console.ReadLine()).ToLower();

            if (Message.Contains("open"))
            {
                sameDevice.OpenClose(true);
            }
            else if (Message.Contains("close"))
            {
                sameDevice.OpenClose(false);
            }
            else
                Console.WriteLine("Set clear instructions!");
        }
        //------------------------------------------------------
        public void ValueInDevice(IValueControl sameDevice)
        {
            Console.Write("Are you want Increase, Decrease or Set value for device? ");
            Message = (Console.ReadLine()).ToLower();

            if (Message.Contains("increase"))
            {
                sameDevice.NextValue();
            }
            else if (Message.Contains("decrease"))
            {

                sameDevice.PreviosValue();
            }
            else if (Message.Contains("set"))
            {
                Console.WriteLine("Set value for device: ");
                try
                {
                    sameDevice.SetValue(Int32.Parse(Console.ReadLine()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
                Console.WriteLine("Set clear instructions!");

        }
 //------------------------------------------

        public void ModeWorkForDevice(IModeOfWork sameDevice)
        {
            Console.WriteLine("Set mode of work for device: ");
            try
            {
                sameDevice.ChangeModeWork(Int32.Parse(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
 //----------------------------------------------------
    }
}
