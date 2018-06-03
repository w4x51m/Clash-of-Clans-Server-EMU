namespace GL.Servers.CoC.Packets.Commands.Server
{
    using GL.Servers.CoC.Logic;

    internal class JoinClan : Command
    {
        public JoinClan(Device Device) : base(Device)
        {
            this.Identifier = 1;
        }

        internal override void Encode()
        {

        }
    }
}
