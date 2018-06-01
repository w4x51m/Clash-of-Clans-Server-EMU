namespace GL.Servers.CoC.Logic.Interfaces
{
    public interface IGameObject
    {
        int ID { get; set; }
        int Data { get; set; }

        int X { get; set; }
        int Y { get; set; }

        int? L1X { get; set; }
        int? L1Y { get; set; }
        int? L2X { get; set; }
        int? L2Y { get; set; }
        int? L3X { get; set; }
        int? L3Y { get; set; }
        int? L4X { get; set; }
        int? L4Y { get; set; }
        int? L5X { get; set; }
        int? L5Y { get; set; }
        int? L6X { get; set; }
        int? L6Y { get; set; }
        int? L7X { get; set; }
        int? L7Y { get; set; }

        void Refresh(float Tick);
    }
}
