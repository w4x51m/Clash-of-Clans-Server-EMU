namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Logic;

    internal class ClanStream : Message
    {
        private Clan Clan;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanStream"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal ClanStream(Device Device, Clan Clan) : base(Device)
        {
            this.Identifier = 24311;
            this.Clan       = Clan;
        }

        internal override void Encode()
        {
            //
        }
    }
}
