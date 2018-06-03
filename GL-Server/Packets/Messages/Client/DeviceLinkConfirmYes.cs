namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class DeviceLinkConfirmYes : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceLinkConfirmYes"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public DeviceLinkConfirmYes(Device Device, Reader Reader) : base(Device, Reader)
        {
            // DeviceLinkConfirmYes.
        }
    }
}