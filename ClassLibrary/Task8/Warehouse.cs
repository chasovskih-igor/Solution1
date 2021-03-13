using System;
using System.Threading;

namespace Implementation
{
    public class Warehouse
    {
        public event Emulator.UnloadMilk WarehouseIsFull;

        public event Emulator.FixBreakage EquipmentBrokeDown;

        public Coordinates Coordinates { get; set; }

        public int FailureChance { get; set; }

        public bool NeedForklift { get; set; }

        public bool NeedMechanic { get; set; }

        public Random Random { get; set; }

        public int ImageId { get; set; }

        public int Workload { get; set; }

        public Warehouse(Coordinates coordinates, int failureChance, Random random)
        {
            Coordinates = coordinates;
            FailureChance = failureChance;
            Random = random;
            NeedForklift = false;
            NeedMechanic = false;
            ImageId = 1;
            Workload = 0;
        }

        public void Run()
        {
            while (true)
            {
                LoadMilk();
                if (!NeedMechanic && !NeedForklift)
                {
                    NeedMechanic = IsFailure();
                    if (NeedMechanic)
                    {
                        ImageId = 6;
                        EquipmentBrokeDown?.Invoke();
                    }
                }
            }
        }

        private bool IsFailure()
        {
            return Random.Next(0, 101) < FailureChance;
        }

        private void LoadMilk()
        {
            if (NeedMechanic || NeedForklift)
            {
                return;
            }
            Thread.Sleep(1000);
            ImageId++;
            Workload++;
            if (Workload == 4)
            {
                NeedForklift = true;
                WarehouseIsFull?.Invoke(this);
            }
        }
    }
}
