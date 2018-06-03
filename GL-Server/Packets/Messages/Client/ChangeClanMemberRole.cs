namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class ChangeClanMemberRole : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeClanMemberRole"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public ChangeClanMemberRole(Device Device, Reader Reader) : base(Device, Reader)
        {
            // ChangeClanMemberRole.
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
            
        }
    }
}