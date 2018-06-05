namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class DeviceLinkCodeDeactivated : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceLinkCodeDeactivated"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public DeviceLinkCodeDeactivated(Device Device) : base(Device)
        {
            this.Identifier = 26004;
        }
    }
}