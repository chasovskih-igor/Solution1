using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class Laptop : Computer
    {
        public Laptop(string make, string model, int memory, int charge) : base(make, model, memory)
        {
            Charge = charge;
        }

        public int Charge { get; set; }
        public bool IsTouchPadWork { get; set; }
        public string TouchPadOn()
        {
            if (IsWorking)
            {
                if (IsTouchPadWork) return "TouchPad works already";
                else return "TouchPad is on successfully ";
            }
            else return "Device is off. You need to turn it on";
        }
        public string TouchPadOff()
        {
            if (IsWorking)
            {
                if (IsTouchPadWork) return "TouchPad doesn't work already";
                else return "TouchPad is off successfully ";
            }
            else return "Device is off. You need to turn it on";
        }
        public override string ChargeCheck()
        {
            if (IsWorking)
            {
                Random rnd = new Random();
                int hour = rnd.Next(1, Charge);
                return "Device have charge for  " + hour.ToString() + "hours of " + Charge.ToString();
            }
            else return "Device is off. You need to turn it on";
        }
    }
}
