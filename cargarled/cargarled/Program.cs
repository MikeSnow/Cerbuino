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

namespace cargarled
{
    public partial class Program
    {
        AnalogInput cargar;
        OutputPort ledv1;
        OutputPort ledv2;
        OutputPort ledv3;
        OutputPort leda1;
        OutputPort leda2;
        OutputPort leda3;
        OutputPort[] leds ;
        int i;
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
            cargar = new AnalogInput((Cpu.AnalogChannel)5);
            ledv1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB11,false);
            ledv2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB10,false);
            ledv3 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB12, false);
            leda1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PC14,false);
            leda2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PC15, false);
            leda3 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PA8, false);
            leds = new OutputPort[6];
            leds[0] = ledv1;
            leds[1] = ledv2;
            leds[2] = ledv3;
            leds[3] = leda1;
            leds[4] = leda2;
            leds[5] = leda3;
            i=0;
            GT.Timer timer = new GT.Timer(300);
            timer.Tick += timer_Tick;
            timer.Start();

            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");
        }

        void timer_Tick(GT.Timer timer)
        {
            double valor = cargar.ReadRaw();
            if (valor > 2000 )
            {
                leds[i].Write(true);
                i++;
            }
            else if (i >= 0)
            {
                leds[i].Write(false);
                i--;
            }
            if (i < 0)
            {
                i = 0;
            }
            if (i > 5)
            {
                i = 5;
            }
            Debug.Print(valor.ToString());
        }
    }
}
