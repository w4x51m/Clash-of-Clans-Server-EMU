using GL.Servers.Extensions.List;

namespace GL.Servers.CoC.Packets.Commands.Server
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    internal class ChangeName : Command
    {
        private string Name;
        private int State;

        public ChangeName(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {

        }

        public ChangeName(Device Device, string Name, int State) : base(Device)
        {
            this.Identifier = 3;
            this.Name       = Name;
            this.State      = State;
        }

        internal override void Encode()
        {
            this.Data.AddString(this.Name);
            this.Data.AddInt(this.State);
            this.Data.AddInt(0);
        }
    }
}
