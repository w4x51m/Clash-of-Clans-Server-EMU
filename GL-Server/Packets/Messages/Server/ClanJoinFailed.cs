namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Logic;

    internal class ClanJoinFailed : Message
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanJoinFailed"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal ClanJoinFailed(Device Device) : base(Device)
        {
            this.Identifier = 24302;
        }
    }
}
