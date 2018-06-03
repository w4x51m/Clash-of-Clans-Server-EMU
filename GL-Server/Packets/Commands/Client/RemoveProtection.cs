namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    using GL.Servers.CoC.Core.Network;
    using GL.Servers.CoC.Packets.Messages.Server;

    internal class RemoveProtection : Command
    {
        public RemoveProtection(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            if (this.Device.Player.Objects.Shield > 0)
            {
                this.Device.Player.Objects.Shield = 0;
            }
            else if (this.Device.Player.Objects.Guard > 0)
            {
                this.Device.Player.Objects.Guard = 0;
            }
            else new Out_Of_Sync(this.Device).Send();
        }
    }
}
