namespace GL.Servers.CoC.Packets.Commands.Server
{
    using GL.Servers.CoC.Logic;

    internal class ChangeClanRole : Command
    {
        public ChangeClanRole(Device Device) : base(Device)
        {
            this.Identifier = 8;
        }

        internal override void Encode()
        {

        }
    }
}
