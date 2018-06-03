namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    internal class NewsSeen : Command
    {
        public NewsSeen(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.Reader.ReadInt32();

            this.Tick = this.Reader.ReadInt32();
        }
    }
}
