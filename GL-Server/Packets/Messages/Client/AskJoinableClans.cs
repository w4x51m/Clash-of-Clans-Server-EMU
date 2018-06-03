namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class AskJoinableClans : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AskJoinableClans"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public AskJoinableClans(Device Device, Reader Reader) : base(Device, Reader)
        {
            // AskJoinableClans.
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            
        }
    }
}