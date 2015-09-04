using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.IO;

namespace Refrigerator
{
    class Program
    {
        Dictionary<string, Device> myDict;
        static void Main(string[] args)

        {

            DeviceCreator myDCreator = new DeviceCreator();
            UIDevice myUI = new UIDevice();



            Dictionary<string, Device> myDict;
            Dictionary<string, Device> smartHoseDevices = new Dictionary<string, Device>();
            
            smartHoseDevices.Add("nord", myDCreator.CreateDevice("refrigerator"));
            smartHoseDevices.Add("mitsubishi", myDCreator.CreateDevice("conditioner"));
            smartHoseDevices.Add("spidola", myDCreator.CreateDevice("radio"));
            
            while (true)
            {
               // Console.Clear();

                Console.WriteLine("Devices in you smart house - " + smartHoseDevices.Count.ToString() + ":");
                foreach (KeyValuePair<string, Device> devices in smartHoseDevices)
                {
                        devices.Value.deviceNotificator += ServiceMessages.Message;
                        Console.WriteLine(devices.Key + " is: " + devices.Value);
                        Console.WriteLine();                   
                    
                }
                Console.WriteLine();
                Console.Write("Enter command: ");

                string[] commands = Console.ReadLine().ToLower().Split(' ');


                switch (commands[0])
                {

                    case "file":
                        SaveLoadMenu(smartHoseDevices);
                        break;

                    case "exit":
                        //FileOperations.SaveBinaryFormat(myDict, "SmartHouse.dat");
                        return;

                    case "add":
                        try
                        {
                            smartHoseDevices.Add(commands[1], myDCreator.CreateDevice(commands[2]));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;

                    case "del":
                        smartHoseDevices.Remove(commands[1]);
                        
                        break;

                    case "power":
                        {
                            
                            foreach (string name in smartHoseDevices.Keys)
                            {
                                if (name == commands[1])
                                {
                                    if ((smartHoseDevices[commands[1]] as IElectricDevice) != null)
                                    {
                                        myUI.PowerDevice(smartHoseDevices[commands[1]]);
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Device does not have such a function!");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        break;

                    case "modework":
                        {

                            foreach (string name in smartHoseDevices.Keys)
                            {
                                if (name == commands[1])
                                {
                                    if ((smartHoseDevices[commands[1]] as IModeOfWork) != null)
                                    {
                                        myUI.ModeWorkForDevice((IModeOfWork)smartHoseDevices[commands[1]]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Device does not have such a function!");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        break;

                    case "controlvalue":
                        {

                            foreach (string name in smartHoseDevices.Keys)
                            {
                                if (name == commands[1])
                                {
                                    if ((smartHoseDevices[commands[1]] as IValueControl) != null)
                                    {
                                        myUI.ValueInDevice((IValueControl)smartHoseDevices[commands[1]]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Device does not have such a function!");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        break;

                    case "door":
                        {

                            foreach (string name in smartHoseDevices.Keys)
                            {
                                if (name == commands[1])
                                {
                                    if ((smartHoseDevices[commands[1]] as IDoorDevice) != null)
                                    {
                                        myUI.DoorDevice((IDoorDevice)smartHoseDevices[commands[1]]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Device does not have such a function!");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        Help();
                        break;



                }


            }


               

            
        }
        private static void Help()
             {
            Console.WriteLine("**********************");
            Console.WriteLine("Доступные типы устройств:");
            Console.WriteLine("Refrigerator, conditioner, radio");
            Console.WriteLine("**********************");
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tAdd NameOfDevice TypeOfDevice");
            Console.WriteLine("\tDel NameOfDevice");
            Console.WriteLine("\tPower NameOfDevice");
            Console.WriteLine("\tModeWork NameOfDevice");
            Console.WriteLine("\tControlValue NameOfDevice");
            Console.WriteLine("\tDoor NameOfDevice");
            Console.WriteLine("\tFileOperation (save or load)");
            Console.WriteLine("\tExit");
            Console.WriteLine("Press any key for continue");
            Console.ReadKey();
                }

        static void SaveLoadMenu(Dictionary<string, Device> myDict)
        {
            Console.Clear();
            Console.WriteLine();
            

            while (true)
            { 
            Console.WriteLine("Enter command: ");

            string command = Console.ReadLine().ToLower();

          
            
                switch (command)
                {
                    case "save bin":
                        
                        FileOperations.SaveBinaryFormat(myDict, "SmartHouse.dat");
                        return;

                    case "save soap":
                        FileOperations.SaveSoapFormat(myDict, "SmartHouse.soap");
                        return;

                    case "save xml":
                        Console.WriteLine("This method is not supported");
                        Console.ReadLine();
                        return;
                        
                    case "load bin":
                        return;
                    case "load soap":
                        return;
                    case "load xml":
                        Console.WriteLine("This method is not supported");
                        Console.ReadLine();
                        return;

                    case "exit":
                        return;

                    default:
                        SaveLoadHelp();
                        break;
                }
            }

        }

        private static void SaveLoadHelp()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tSave Binary");
            Console.WriteLine("\tLoad Bimary");
            Console.WriteLine("\tSave SOAP");
            Console.WriteLine("\tLoad SOAP");
            Console.WriteLine("\tSave XML");
            Console.WriteLine("\tLoad XML");
            Console.WriteLine("\texit");
            Console.WriteLine("Press any key for continue");
            Console.ReadKey();

        }
    }
           
}



 //nord.refrigeratorNotificator += message => Console.WriteLine("Service message: " + message);
//nord.refrigeratorNotificator += ServiceMessages.Message;

