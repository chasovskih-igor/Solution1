using System.Threading;

namespace Implementation
{
    public class Mechanic
    {
        public Coordinates BaseCoordinates { get; set; }

        public Coordinates NextCoordinates { get; set; }

        public Warehouse Warehouse { get; set; }

        public Mechanic(Coordinates baseCoordinates, Coordinates nextCoordinates, Warehouse warehouse)
        {
            BaseCoordinates = baseCoordinates;
            NextCoordinates = nextCoordinates;
            Warehouse = warehouse;
        }

        public void Repair()
        {
            while (!NextCoordinates.IsLocatedIn(Warehouse.Coordinates))
            {
                MoveTo(Warehouse.Coordinates);
            }
            Thread.Sleep(1000);
            Warehouse.NeedMechanic = false;
            Warehouse.Workload = 0;
            Warehouse.ImageId = 1;
            MoveToHome();
        }

        public bool InHouse()
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

        public void MoveToHome()
        {
            while (!NextCoordinates.IsLocatedIn(BaseCoordinates))
            {
                MoveTo(BaseCoordinates);
            }
        }
    }
}
