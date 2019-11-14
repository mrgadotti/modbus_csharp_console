using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EasyModbus;

namespace modbus_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start...");
            ModbusClient modbusClient = new ModbusClient("192.168.255.1", 502);
            modbusClient.Connect();
            modbusClient.WriteSingleCoil(8, true);
            Thread.Sleep(1000);
            modbusClient.WriteSingleCoil(8, false);
            bool[] readInputs = modbusClient.ReadDiscreteInputs(0, 11);
            for (int i = 0; i < readInputs.Length; i++)
                Console.WriteLine("Value of input "+ readInputs[i].ToString());
        }
    }
}
