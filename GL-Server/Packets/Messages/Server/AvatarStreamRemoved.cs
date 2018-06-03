namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class AvatarStreamRemoved : Message
    {
        private int HighID;
        private int LowID;

        /// <summary>
        /// Initializes a new instance of the <see cref="AvatarStreamRemoved"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public AvatarStreamRemoved(Device Device, int HighID, int LowID) : base(Device)
        {
            this.Identifier = 24412;

            this.HighID     = HighID;
            this.LowID      = LowID;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt(this.HighID);
            this.Data.AddInt(this.LowID);
        }
    }
}