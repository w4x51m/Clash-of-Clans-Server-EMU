namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Logic;

    internal class ClanChangeFailed : Message
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanChangeFailed"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal ClanChangeFailed(Device Device) : base(Device)
        {
            this.Identifier = 24332;
        }
    }
}
