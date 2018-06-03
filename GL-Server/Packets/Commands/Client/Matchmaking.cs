using GL.Servers.CoC.Core;

namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    internal class Matchmaking : Command
    {
        public Matchmaking(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.Reader.ReadInt32();
            this.Reader.ReadInt32();

            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            Resources.Battles.Start_PVP(this.Device.Player);
        }
    }
}
