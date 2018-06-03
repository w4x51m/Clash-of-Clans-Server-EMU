namespace GL.Servers.CoC.Packets.Commands.Server
{
    using GL.Servers.CoC.Logic;

    internal class DonateClanUnit : Command
    {
        public DonateClanUnit(Device Device) : base(Device)
        {
            this.Identifier = 4;
        }

        internal override void Encode()
        {

        }
    }
}
