namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    internal class ShieldCostSeen : Command
    {
        public ShieldCostSeen(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.Reader.ReadInt32();
            this.Reader.ReadByte();

            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
        }
    }
}
