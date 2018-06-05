namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Logic;

    internal class ReportUserStatus : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportUserStatus"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal ReportUserStatus(Device Device) : base(Device)
        {
            this.Identifier = 20117;
        }
    }
}