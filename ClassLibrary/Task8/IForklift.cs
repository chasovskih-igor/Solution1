namespace Implementation
{
    public interface IForklift
    {
        Coordinates BaseCoordinates { get; set; }

        Coordinates NextCoordinates { get; set; }

        bool InBaseCoordinates();

        void MoveTo(Coordinates coordinates);

        void NeedToUnload(Warehouse warehouse);

        void Run();

        void Unload(Warehouse warehouse);
    }
}
