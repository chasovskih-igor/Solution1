using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class Smartphone : Computer
    {
        public bool Flashkight { get; set; }
        public int Charge { get; set; }
        public Smartphone(string make, string model, int memory, bool flashkight, int charge) : base(make, model, memory)
        {
            Flashkight = flashkight;
            Charge = charge;
        }
        public string ChargeCheck()
        {
            if (IsWorking)
            {
                Random rnd = new Random();
                int restCharge = rnd.Next(1, Charge);
                if (restCharge < 20) return "Device have less 20% of charge. Plug on the charger";
                return "Device have " + restCharge.ToString() + "%";
            }
            return "Device is off. You need to turn it on";
        }
        public bool IsFlashlight()
        {
            if (IsWorking)
            {
                Flashkight = true;
            }
            return false;
        }
    }
}
