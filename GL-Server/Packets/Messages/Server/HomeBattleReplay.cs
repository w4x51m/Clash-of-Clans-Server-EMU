namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;
    using GL.Servers.Library.ZLib;

    internal class HomeBattleReplay : Message
    {
        private string Replay;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeBattleReplay"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public HomeBattleReplay(Device Device, string Replay) : base(Device)
        {
            this.Identifier = 24114;

            this.Replay     = Replay;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            byte[] Compressed = ZlibStream.CompressString(this.Replay);

            this.Data.AddInt(Compressed.Length + 4);
            this.Data.AddIntEndian(this.Replay.Length);
            this.Data.AddRange(Compressed);
        }
    }
}