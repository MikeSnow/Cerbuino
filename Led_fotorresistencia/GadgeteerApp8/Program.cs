using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;
using Microsoft.SPOT.Hardware;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using GHI.Hardware.FEZCerb;
using System;

namespace GadgeteerApp8
{
    public partial class Program
    {
        AnalogInput foto;
        OutputPort verde;
        OutputPort amarillo;
        OutputPort rojo;
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

            foto = new AnalogInput((Cpu.AnalogChannel)5);
            double i = foto.Read();
            verde = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB3, false);
            amarillo = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB4, false);
            rojo = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB5, false);
            GT.Timer timer = new GT.Timer(300);
            timer.Tick += timer_Tick;
            timer.Start();
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");
        }

        void timer_Tick(GT.Timer timer)
        {
            double i = foto.ReadRaw();
            if (i < 2000)
            {
                verde.Write(true);
                amarillo.Write(false);
                rojo.Write(false);
            }
            else if (i < 3000)
            {
                amarillo.Write(true);
                verde.Write(false);
                rojo.Write(false);
            }
            else
            {
                rojo.Write(true);
                verde.Write(false);
                amarillo.Write(false);
            }
            string texto = i.ToString();
            Debug.Print(i.ToString());
        }
    }
}
