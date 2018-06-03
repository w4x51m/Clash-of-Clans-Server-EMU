namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    internal class SendGlobalChatLine : Message
    {
        private string Message;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendGlobalChatLine"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public SendGlobalChatLine(Device Device, Reader Reader) : base(Device, Reader)
        {
            // GlobalChatLine.
        }

        /// <summary>
        /// Decodes this message.
        /// </summary>
        internal override void Decode()
        {
            this.Message = this.Reader.ReadString();
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            this.Device.Player.Chat?.Entry(this.Device.Player, this.Message);
        }
    }
}
