using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refrigerator
{
    public class ServiceMessages
    {
        public static void Message (string message)
        {
            int leftPos = Console.CursorLeft;
            int topPs = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Blue;
            //Console.SetCursorPosition(15, 20);
            Console.WriteLine("Service message: "+ message);
            Console.ResetColor();
            //Console.SetCursorPosition(leftPos, topPs);
        }
    }
}
