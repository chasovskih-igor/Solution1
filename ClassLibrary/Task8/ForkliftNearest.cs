using System.Collections.Generic;
using System.Threading;

namespace Implementation
{
    public class ForkliftNearest : IForklift
    {
        public Coordinates BaseCoordinates { get; set; }

        public Coordinates NextCoordinates { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        public ForkliftNearest(Coordinates baseCoordinates, Coordinates nextCoordinates)
        {
            BaseCoordinates = baseCoordinates;
            NextCoordinates = nextCoordinates;
            Warehouses = new List<Warehouse>();
        }

        public bool InBaseCoordinates()
        {
            return NextCoordinates.IsLocatedIn(BaseCoordinates);
        }

        public void MoveTo(Coordinates coordinates)
        {
            Thread.Sleep(100);
            if (!NextCoordinates.IsLocatedIn(coordinates))
            {
                NextCoordinates.ShiftTo(coordinates);
            }
        }

        public void NeedToUnload(Warehouse warehouse)
        {
            Warehouses.Add(warehouse);
        }

        public Warehouse Next()
        {
            Warehouse warehouse = null;
            foreach (Warehouse current in Warehouses)
            {
                if (warehouse == null)
                {
                    warehouse = current;
                }
                else
                {
                    if (NextCoordinates.CalculateDistanceTo(warehouse.Coordinates) > NextCoordinates.CalculateDistanceTo(current.Coordinates))
                    {
                        warehouse = current;
                    }
                }
            }
            return warehouse;
        }

        public void Run()
        {
            while (true)
            {
                if (Warehouses.Count == 0)
                {
                    MoveTo(BaseCoordinates);
                }
                else
                {
                    Warehouse warehouse = Next();
                    while (!NextCoordinates.IsLocatedIn(warehouse.Coordinates))
                    {
                        MoveTo(warehouse.Coordinates);
                    }
                    Unload(warehouse);
                }
            }
        }

        public void Unload(Warehouse warehouse)
        {
            Thread.Sleep(1000);
            warehouse.Workload = 0;
            warehouse.NeedForklift = false;
            warehouse.ImageId = 1;
            Warehouses.Remove(warehouse);
        }
    }
}
