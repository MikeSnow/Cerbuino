using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;
using System.Text;
using Microsoft.SPOT.Net;
using Microsoft.SPOT.Hardware;
using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using GTI = Gadgeteer.Interfaces;
using System.IO.Ports;
namespace HelloWorldBluetooth
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            /*******************************************************************************************
            Modules added in the Program.gadgeteer designer view are used by typing 
            their name followed by a period, e.g.  button.  or  camera.
            
            Many modules generate useful events. Type +=<tab><tab> to add a handler to an event, e.g.:
                button.ButtonPressed +=<tab><tab>
            
            If you want to do something periodically, use a GT.Timer and handle its Tick event, e.g.:
                GT.Timer timer = new GT.Timer(1000); // every second (1000ms)
                timer.Tick +=<tab><tab>
                timer.Start();
            *******************************************************************************************/
            SerialPort UART = new SerialPort("COM3", 115200);
            int counter = 0;
            UART.Open();
            while (true)
            {
                // create a string
                string counter_string = "Count: " + counter.ToString() +
                                    "\r\n";
                // convert the string to bytes
                byte[] buffer = Encoding.UTF8.GetBytes(counter_string);
                // send the bytes on the serial port
                UART.Write(buffer, 0, buffer.Length);
                // increment the counter;
                counter++;
                //wait...
                Thread.Sleep(100);
                Debug.Print(counter_string);
            }
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            
        }
    }
}
