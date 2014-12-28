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

namespace Led_boton_foto
{
    public partial class Program
    {
        OutputPort rojo;
        AnalogInput cuerpo;
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

            cuerpo = new AnalogInput((Cpu.AnalogChannel)5);
            rojo = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB3,false);
            GT.Timer timer = new GT.Timer(100);
            timer.Tick += timer_Tick;
            timer.Start();
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");
        }

        void timer_Tick(GT.Timer timer)
        {
            double i = cuerpo.ReadRaw();
            if (i < 100)
            {
                rojo.Write(true);
            }
            else
            {
                rojo.Write(false);
            }
            Debug.Print(i.ToString());
        }
    }
}
