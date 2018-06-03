using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Logic.Components;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    internal class CollectResources : Command
    {
        private int ID;

        public CollectResources(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.ID   = this.Reader.ReadInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            if (!this.Device.Player.Objects.Buildings[this.ID].Collect())
            {
                new Out_Of_Sync(this.Device).Send();
            }
        }
    }
}
