using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace SMT
{
    public class Settings
    {
        static string path = @"SOFTWARE\SMT-SUPPORT\Configs";
        public class Port
        {
            public static string PortName = "COM1";
            public static int BaudRate = 9600;
            public static Parity Parity = Parity.None;
            public static StopBits StopBits = StopBits.One;
            public static int DataBits = 8;
            public static bool EnableCom = true;
        }
        public class DataMode
        {
            public static string OK;
            public static string NG;
            public static string WR;
        }
        public class RunTime
        {
            public static int SleepTime = 10000;
            public static List<string> Lines = new List<string>();
        }
        public static void Read()
        {
            Port.PortName = Ultils.GetValueRegistryKey(path, "PortName");
            var value = Ultils.GetValueRegistryKey(path, "BaudRate");
            int baudRate = 0;
            if (!int.TryParse(value, out baudRate))
            {
                baudRate = 9600;
            }
            Port.BaudRate = baudRate;
            value = Ultils.GetValueRegistryKey(path, "Parity");
            if (value != null)
            {

                Port.Parity = (Parity)Enum.Parse(typeof(Parity), value);
            }
            value = Ultils.GetValueRegistryKey(path, "StopBits");

            if (value != null)
            {

                Port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), value);
            }
            value = Ultils.GetValueRegistryKey(path, "DataBits");
            int dataBits = 0;
            if (!int.TryParse(value, out dataBits))
            {
                dataBits = 8;
            }
            Port.DataBits = dataBits;
            value = Ultils.GetValueRegistryKey(path, "UseComport");
            Port.EnableCom = Convert.ToBoolean(value);
            DataMode.OK = Ultils.GetValueRegistryKey(path, "SignalOK");
            DataMode.NG = Ultils.GetValueRegistryKey(path, "SignalNG");
            DataMode.WR = Ultils.GetValueRegistryKey(path, "SignalWR");
            value = Ultils.GetValueRegistryKey(path, "SleepTime");
            int sleepTime = 0;
            if (!int.TryParse(value, out sleepTime))
            {
                sleepTime = 10000;
            }
            RunTime.SleepTime = sleepTime;
            value = Ultils.GetValueRegistryKey(path, "Lines");
            if (value != null)
            {

                RunTime.Lines = value.Split(',').ToList();
            }
        }
        public static void Write()
        {
            Ultils.WriteRegistry(path, "UseComport", Port.EnableCom.ToString());
            Ultils.WriteRegistry(path, "BaudRate", Port.BaudRate.ToString());
            Ultils.WriteRegistry(path, "DataBits", Port.DataBits.ToString());
            Ultils.WriteRegistry(path, "Parity", Port.Parity.ToString());
            Ultils.WriteRegistry(path, "StopBits", Port.StopBits.ToString());
            Ultils.WriteRegistry(path, "PortName", Port.PortName);
            Ultils.WriteRegistry(path, "SignalOK", DataMode.OK);
            Ultils.WriteRegistry(path, "SignalNG", DataMode.NG);
            Ultils.WriteRegistry(path, "SignalWR", DataMode.WR);
            Ultils.WriteRegistry(path, "SleepTime", RunTime.SleepTime.ToString());
            Ultils.WriteRegistry(path, "Lines", String.Join(",", RunTime.Lines.OrderBy(r => r).ToArray()));
        }
    }
}
