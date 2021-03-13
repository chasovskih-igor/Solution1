using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public abstract class Computer : IComputingDevice
    {

        public bool IsWorking { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Memory { get; set; }

        public Computer(string make, string model, int memory)
        {
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            Make = make;
            Model = model;
            Memory = memory;
        }


        public string DeviceOn()
        {
            IsWorking = true;
            return "Device is on";
        }
        public string DeviceOff()
        {
            IsWorking = false;
            return "Device is off";
        }
        public string Reboot()
        {
            if (IsWorking)
            {
                return "Device is rebooting";
            }
            else return "Device is off. You need to turn it on";
        }
        public string Sleep()
        {
            if (IsWorking)
            {
                return "Device is in hibernation";
            }
            else return "Device is off. You need to turn it on";
        }
    }
}
