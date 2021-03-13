﻿using System.Collections.Generic;
using System.Threading;

namespace Implementation
{
    public class ForkliftDefault : IForklift
    {
        public Coordinates BaseCoordinates { get; set; }

        public Coordinates NextCoordinates { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        public ForkliftDefault(Coordinates baseCoordinates, Coordinates nextCoordinates)
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
                    while (!NextCoordinates.IsLocatedIn(Warehouses[0].Coordinates))
                    {
                        MoveTo(Warehouses[0].Coordinates);
                    }
                    Unload(Warehouses[0]);
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
