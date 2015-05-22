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

namespace GadgeteerApp6
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset. 
        OutputPort ruedaUpI1;
        OutputPort ruedaUpI2;
        OutputPort ruedaUpD1;
        OutputPort ruedaUpD2;
        OutputPort ruedaBackI1;
        OutputPort ruedaBackI2;
        OutputPort ruedaBackD1;
        OutputPort ruedaBackD2;
        bool i;
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
            
            ********************************************************************************************/
            AnalogOutput prueba = new AnalogOutput(Cpu.AnalogOutputChannel.ANALOG_OUTPUT_0);
            ruedaUpI1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB10, false);
            ruedaUpI2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB12, false);
            ruedaUpD1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PC14, false);
            ruedaUpD2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PC15, false);
            ruedaBackI1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB13, false);
            ruedaBackI2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PA9, false);
            ruedaBackD1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PA15, false);
            ruedaBackD2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB5, false);
            prueba.Scale = 1;
            prueba.Write(5000);
            i = false;
            GT.Timer timer = new GT.Timer(10000);
            timer.Tick += timer_Tick;
            timer.Start();

          
            Debug.Print("Program Started");
        }

        void timer_Tick(GT.Timer timer)
        {
            if (i) {
                ruedaUpI1.Write(false);
                ruedaUpI2.Write(false);
                ruedaUpD1.Write(false);
                ruedaUpD2.Write(false);
                ruedaBackI1.Write(true);
                ruedaBackI2.Write(true);
                ruedaBackD1.Write(true);
                ruedaBackD2.Write(true);
                i=false;
                Debug.Print("Detras");
            }else{
                ruedaBackI1.Write(false);
                ruedaBackI2.Write(false);
                ruedaBackD1.Write(false);
                ruedaBackD2.Write(false);
                ruedaUpI1.Write(true);
                ruedaUpI2.Write(true);
                ruedaUpD1.Write(true);
                ruedaUpD2.Write(true);
                Debug.Print("Delante");
                i=true;
            }
        }
    }
}
