using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class Navigator : Computer
    {
        public int Charge { get; set; }
        public string Destination { get; set; }
        public Navigator(string make, string model, int memory, int charge, string destination) : base(make, model, memory)
        {
            Charge = charge;
            Destination = destination;
        }
        public string LeadTheWay()
        {
            if (IsWorking)
            {
                Random rnd = new Random();
                double range = rnd.Next();
                return "You will reach the destination in " + range.ToString() + "km";
            }
            return "Device is off. You need to turn it on";
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
    }
}
