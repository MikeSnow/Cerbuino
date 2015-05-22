using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using GHIElectronics.Gadgeteer;

namespace cocheCerbuinoBT
{
    class Coche
    {
        //atributos
        OutputPort ruedaUpI1;
        OutputPort ruedaUpI2;
        OutputPort ruedaUpD1;
        OutputPort ruedaUpD2;
        OutputPort ruedaBackI1;
        OutputPort ruedaBackI2;
        OutputPort ruedaBackD1;
        OutputPort ruedaBackD2;
        public Coche()
        {
            ruedaUpI1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PC14, false);//D3
            ruedaUpI2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PC15, false);//D4
            ruedaUpD1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PA10, false);//D5
            ruedaUpD2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PC4, false);//D7
            ruedaBackI1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB13, false);//D8
            ruedaBackI2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PA9, false);//D9
            ruedaBackD1 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PA15, false);//D10
            ruedaBackD2 = new OutputPort((Cpu.Pin)GHI.Hardware.FEZCerb.Pin.PB5, false);//D11
        }
        public void delante()
        {
            ruedaUpI2.Write(false);
            ruedaUpD2.Write(false);
            ruedaBackI2.Write(false);
            ruedaBackD2.Write(false);
            ruedaUpI1.Write(true);
            ruedaUpD1.Write(true);
            ruedaBackI1.Write(true);
            ruedaBackD1.Write(true);   
        }
        public void detras()
        {
            ruedaUpI1.Write(false);
            ruedaUpD1.Write(false);
            ruedaBackI1.Write(false);
            ruedaBackD1.Write(false);
            ruedaUpI2.Write(true);
            ruedaUpD2.Write(true);
            ruedaBackI2.Write(true);
            ruedaBackD2.Write(true);
            
        }
        public void izquierda()
        {
            ruedaUpI1.Write(true);
            ruedaUpI2.Write(false);
            ruedaUpD1.Write(false);
            ruedaUpD2.Write(false);
            ruedaBackI1.Write(true);
            ruedaBackI2.Write(false);
            ruedaBackD1.Write(false);
            ruedaBackD2.Write(false);
        }
        public void derecha()
        {
            ruedaUpI1.Write(false);
            ruedaUpI2.Write(false);
            ruedaUpD1.Write(true);
            ruedaUpD2.Write(false);
            ruedaBackI1.Write(false);
            ruedaBackI2.Write(false);
            ruedaBackD1.Write(true);
            ruedaBackD2.Write(false);
        }
        public void alantederecha()
        {
            ruedaUpI1.Write(false);
            ruedaUpI2.Write(false);
            ruedaUpD1.Write(false);
            ruedaUpD2.Write(false);
            ruedaBackI1.Write(true);
            ruedaBackI2.Write(true);
            ruedaBackD1.Write(true);
            ruedaBackD2.Write(true);
        }
        public void alanteizquierda()
        {
            ruedaUpI1.Write(false);
            ruedaUpI2.Write(false);
            ruedaUpD1.Write(false);
            ruedaUpD2.Write(false);
            ruedaBackI1.Write(true);
            ruedaBackI2.Write(true);
            ruedaBackD1.Write(true);
            ruedaBackD2.Write(true);
        }
        public void detrasderecha()
        {
            ruedaUpI1.Write(false);
            ruedaUpI2.Write(false);
            ruedaUpD1.Write(false);
            ruedaUpD2.Write(false);
            ruedaBackI1.Write(true);
            ruedaBackI2.Write(true);
            ruedaBackD1.Write(true);
            ruedaBackD2.Write(true);
        }
        public void detrasizquierda()
        {
            ruedaUpI1.Write(false);
            ruedaUpI2.Write(false);
            ruedaUpD1.Write(false);
            ruedaUpD2.Write(false);
            ruedaBackI1.Write(true);
            ruedaBackI2.Write(true);
            ruedaBackD1.Write(true);
            ruedaBackD2.Write(true);
        }

    }
}
