namespace GL.Servers.CoC.Packets.Commands.Server
{
    using GL.Servers.CoC.Logic;

    internal class ClanSettingsChanged : Command
    {
        public ClanSettingsChanged(Device Device) : base(Device)
        {
            this.Identifier = 6;
        }

        internal override void Encode()
        {

        }
    }
}
