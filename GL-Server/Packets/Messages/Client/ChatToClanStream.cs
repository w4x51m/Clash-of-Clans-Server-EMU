namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class ChatToClanStream : Message
    {
        private string Message;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatToClanStream"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public ChatToClanStream(Device Device, Reader Reader) : base(Device, Reader)
        {
            // ChatToClanStream.
        }

        internal override void Decode()
        {
            this.Message = this.Reader.ReadString();
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            // Process.
        }
    }
}