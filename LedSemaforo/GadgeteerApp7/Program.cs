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
using GHI.OSHW.Hardware;
using GHI.Premium.Hardware;

namespace GadgeteerApp7
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset. 
        OutputPort verde;
        OutputPort amarillo;
        OutputPort rojo;
        int i;
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
            this.i = 0;
            verde = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB3, true);
            amarillo = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB4, false);
            rojo = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB5, false);
            GT.Timer timer = new GT.Timer(500);
            timer.Tick += timer_Tick;
            timer.Start();

            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");
        }

        void timer_Tick(GT.Timer timer)
        {
            if (i == 0)
            {
                verde.Write(true);
                amarillo.Write(false);
                rojo.Write(false);
                Debug.Print("verde");
                i=1;
            }
            else
            {
                if (i == 1)
                {
                    amarillo.Write(true);
                    verde.Write(false);
                    rojo.Write(false);
                    Debug.Print("amarillo");
                    i = 2;
                }
                else
                {
                    rojo.Write(true);
                    verde.Write(false);
                    amarillo.Write(false);
                    Debug.Print("rojo");
                    i = 0;
                }
            }
        }
    }
}
