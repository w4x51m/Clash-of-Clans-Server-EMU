namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class DeviceLinkMenuClosed : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceLinkMenuClosed"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public DeviceLinkMenuClosed(Device Device, Reader Reader) : base(Device, Reader)
        {
            // DeviceLinkMenuClosed.
        }
    }
}