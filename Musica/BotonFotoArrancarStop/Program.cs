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
using GHI;

namespace BotonFotoArrancarStop
{
    public partial class Program
    {
        AnalogInput prueba;
        AnalogInput prueba2;
        OutputPort ledv1;
        OutputPort ledv2;
        OutputPort ledv3;
        OutputPort leda1;
        OutputPort leda2;
        OutputPort leda3;
        OutputPort ledr1;
        OutputPort ledr2;
        OutputPort ledr3;
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
            prueba = new AnalogInput((Cpu.AnalogChannel)5);
            prueba2 = new AnalogInput((Cpu.AnalogChannel)4);
            ledv1=new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB11,false);
            ledv2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB10, false);
            ledv3 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB12, false);
            leda1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PC14, false);
            leda2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PC15, false);
            leda3 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PA8, false);
            ledr1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PA10, false);
            ledr2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PC4, false);
            ledr3 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB13, false);
            GT.Timer timer = new GT.Timer(1);
            timer.Tick += timer_Tick;
            timer.Start();
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");
        }

        void timer_Tick(GT.Timer timer)
        {
            double valor = prueba.ReadRaw();
            double valor2= prueba2.ReadRaw();
            if (valor > 100 )
            {
                ledv1.Write(true);
            }
            else
            {
                ledv1.Write(false);
            }
            if (valor > 300)
            {
                ledv2.Write(true);
            }
            else
            {
                ledv2.Write(false);
            }
            if (valor > 500 )
            {
                ledv3.Write(true);
            }
            else
            {
                ledv3.Write(false);
            }
            if (valor > 700 )
            {
                leda1.Write(true);
            }
            else
            {
                leda1.Write(false);
            }
            if (valor > 900 || valor2>900)
            {
                leda2.Write(true);
            }
            else
            {
                leda2.Write(false);
            }
            if (valor2 > 700 )
            {
                leda3.Write(true);
            }else{
                leda3.Write(false);
            }
            if (valor2 > 500)
            {
                ledr1.Write(true);
            }
            else
            {
                ledr1.Write(false);
            }
            if (valor2 > 300)
            {
                ledr2.Write(true);
            }
            else
            {
                ledr2.Write(false);
            }
            if (valor2 > 100)
            {
                ledr3.Write(true);
            }
            else
            {
                ledr3.Write(false);
            }
        }
    }
}
