namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class DeviceLinkNewDeviceLinked : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceLinkNewDeviceLinked"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public DeviceLinkNewDeviceLinked(Device Device) : base(Device)
        {
            this.Identifier = 26003;
        }
    }
}