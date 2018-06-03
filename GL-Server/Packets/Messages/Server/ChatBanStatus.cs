namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class ChatBanStatus : Message
    {
        private int Time;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatBanStatus"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal ChatBanStatus(Device Device, int Time) : base(Device)
        {
            this.Identifier = 20118;
            this.Time       = Time;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt(this.Time);
        }
    }
}
