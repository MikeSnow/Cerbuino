using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;

namespace cocheCerbuinoBT
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.  
        Bluetooth bt;
        Coche co;
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
            bt = new Bluetooth();
            co = new Coche();
            GT.Timer timer = new GT.Timer(10);
            timer.Tick += timer_Tick;
            timer.Start();
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");
        }

        void timer_Tick(GT.Timer timer)
        {
            String texto = bt.LecturaBT();
            if (texto != null)
            {
                Debug.Print(texto);
                int estado = Int32.Parse(texto);
                switch (estado)
                {
                    case 1:
                        co.delante();
                        Debug.Print("delante");
                        break;
                    case 2:
                        co.detras();
                        break;
                    case 3:
                        co.derecha();
                        break;
                    case 4:
                        co.izquierda();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                }    
            }
            
        }
    }
}
