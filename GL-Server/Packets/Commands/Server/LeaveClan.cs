using GL.Servers.CoC.Logic;

namespace GL.Servers.CoC.Packets.Commands.Server
{
    internal class LeaveClan : Command
    {
        public LeaveClan(Device Device) : base(Device)
        {
            this.Identifier = 2;
        }

        internal override void Encode()
        {
            
        }
    }
}
