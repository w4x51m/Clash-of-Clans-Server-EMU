namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class LeaveClan : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeaveClan"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public LeaveClan(Device Device, Reader Reader) : base(Device, Reader)
        {
            // LeaveClan.
        }
        
        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            
        }
    }
}