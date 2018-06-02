namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;
    using GL.Servers.CoC.Core.Network;
    using GL.Servers.CoC.Packets.Messages.Server;

    internal class BuyBuilding : Command
    {
        private int Data;
        private int X;
        private int Y;

        public BuyBuilding(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.X    = this.Reader.ReadInt32();
            this.Y    = this.Reader.ReadInt32();
            this.Data = this.Reader.ReadInt32();

            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            if (!this.Device.Player.Objects.Buildings.Construct(this.Data, this.X, this.Y))
            {
                new Out_Of_Sync(this.Device).Send();
            }
        }
    }
}
