namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Logic;

    internal class ClanCreateFailed : Message
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanCreateFailed"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal ClanCreateFailed(Device Device) : base(Device)
        {
            this.Identifier = 24332;
        }
    }
}
