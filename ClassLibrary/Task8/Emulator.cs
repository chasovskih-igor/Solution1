using System.Collections.Generic;
using System.Threading;

namespace Implementation
{
    public class Emulator
    {
        public delegate void UnloadMilk(Warehouse warehouse);

        public delegate void FixBreakage();

        public IForklift Forklift { get; set; }

        public List<Mechanic> Mechanics { get; set; }

        public List<Thread> Threads { get; set; }

        public Emulator(IForklift forklift, List<Mechanic> mechanics)
        {
            Forklift = forklift;
            Mechanics = mechanics;
            Threads = new List<Thread>();
        }

        public void Abort()
        {
            foreach (Thread thread in Threads)
            {
                thread.Abort();
            }
        }

        public void Run()
        {
            for (int i = 0; i < Mechanics.Count; i++)
            {
                Mechanics[i].Warehouse.WarehouseIsFull += Forklift.NeedToUnload;
                Mechanics[i].Warehouse.EquipmentBrokeDown += Mechanics[i].Repair;
                Thread mechanicThread = new Thread(Mechanics[i].Warehouse.Run);
                mechanicThread.Start();
                Threads.Add(mechanicThread);
            }
            Thread forkliftThread = new Thread(Forklift.Run);
            forkliftThread.Start();
            Threads.Add(forkliftThread);
        }
    }
}
