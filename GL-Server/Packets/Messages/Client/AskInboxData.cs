namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class AskInboxData : Message
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AskInboxData"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public AskInboxData(Device Device, Reader Reader) : base(Device, Reader)
        {
            // AskInboxData.
        }

        /// <summary>
        /// Decodes this message.
        /// </summary>
        internal override void Decode()
        {
            this.Reader.ReadByte();
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {

        }
    }
}