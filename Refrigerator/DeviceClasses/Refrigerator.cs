using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refrigerator
{
    [Serializable]
    public class Refrigerator : Device, IDoorDevice, IElectricDevice, IValueControl, IModeOfWork
    {
        
        public ModeRefrigerator ModeWork { set; get; }
        public bool IsOpen { set; get; }

       
        public override event Notificator deviceNotificator;

        int Temperature { set; get; }


        public Refrigerator()
            : base()
        {
            ModeWork = ModeRefrigerator.defrost;
            Temperature = 20;
            IsOpen = false;
        }

        public override void InclusionShutdown(bool PowerOn)
        {
            base.InclusionShutdown(PowerOn);
            if (deviceNotificator != null)
            {
                deviceNotificator.Invoke("Refrigerator power is " + PowerOn.ToString());
            }
        }

        public void OpenClose(bool IsOpen)
        {
            this.IsOpen = IsOpen;
            if (deviceNotificator != null)
            {
                deviceNotificator.Invoke("Refrigerator door is " + IsOpen.ToString());
            }
        }

        public void PreviosValue()
        {
            Temperature -= 1;
            if (deviceNotificator != null)
            {
               
                deviceNotificator.Invoke("Temperature set to " + Temperature.ToString());
            }

        }

        public void NextValue()
        {
            Temperature += 1;
           
            if (deviceNotificator != null)
            {
                deviceNotificator.Invoke("Temperature set to " + Temperature.ToString());
            }
        }

        public void SetValue (int needValue)
        {
            Temperature = needValue;

            if (deviceNotificator != null)
            {
                deviceNotificator.Invoke("Temperature set to " + Temperature.ToString());
            }
        }
        public override string ToString()
        {
            return base.ToString() + " ,door - " + IsOpen.ToString() + " mode work is : " + ModeWork.ToString() + " , temperature is : " + Temperature.ToString();
        }

        public void ChangeModeWork(int neededModeWork)
        {
            switch (neededModeWork)
            {
                case 1:
                    ModeWork = ModeRefrigerator.extraCold;
                    if (deviceNotificator != null)
                    {
                        deviceNotificator.Invoke("Mode of Work choose Extra Cold");
                    }

                    break;

                case 2:
                    ModeWork = ModeRefrigerator.cold;
                    if (deviceNotificator != null)
                    {
                        deviceNotificator.Invoke("Mode of Work choose Extra Cold");
                    }

                    break;

                case 3:
                    ModeWork = ModeRefrigerator.frost;
                    if (deviceNotificator != null)
                    {
                        deviceNotificator.Invoke("Mode of Work choose Extra Cold");
                    }

                    break;

                case 4:
                default:
                    ModeWork = ModeRefrigerator.defrost;
                    if (deviceNotificator != null)
                    {
                        deviceNotificator.Invoke("Mode of Work choose Extra Cold");
                    }

                    break;


            }



        }
    }
}
