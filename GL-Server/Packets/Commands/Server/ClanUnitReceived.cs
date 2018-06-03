namespace GL.Servers.CoC.Packets.Commands.Server
{
    using GL.Servers.CoC.Logic;

    internal class ClanUnitReceived : Command
    {
        public ClanUnitReceived(Device Device) : base(Device)
        {
            this.Identifier = 5;
        }

        internal override void Encode()
        {

        }
    }
}
