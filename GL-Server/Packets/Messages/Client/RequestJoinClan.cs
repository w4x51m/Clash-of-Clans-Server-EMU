namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class RequestJoinClan : Message
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestJoinClan"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public RequestJoinClan(Device Device, Reader Reader) : base(Device, Reader)
        {
            // RequestJoinClan.
        }

        internal override void Decode()
        {
            this.Debug();
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