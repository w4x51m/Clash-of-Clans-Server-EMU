namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Logic;

    internal class ClanData : Message
    {
        private Clan Clan;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanData"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal ClanData(Device Device, Clan Clan) : base(Device)
        {
            this.Identifier = 24332;
            this.Clan       = Clan;
        }

        internal override void Encode()
        {
            this.Data.AddRange(this.Clan.ToBytes);
        }
    }
}
