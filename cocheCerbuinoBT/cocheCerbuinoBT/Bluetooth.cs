using System;
using Microsoft.SPOT;
using System.IO.Ports;
using System.Text;

namespace cocheCerbuinoBT
{
    class Bluetooth
    {
        // Atributos
        SerialPort UART;

        public Bluetooth()
        {
           this.UART = new SerialPort("COM3", 9600);
           this.UART.Open();
        }

        public String LecturaBT()
        {
            string salida;
            int contador = this.UART.BytesToRead;
            byte[] buffer = new byte[this.UART.BytesToRead];
            contador = UART.Read(buffer, 0, this.UART.BytesToRead);
            if (contador > 0)
            {
                salida =new string(Encoding.UTF8.GetChars(buffer));
            }
            else
            {
                salida = null;
            }
            return salida;
        }
    }
}
