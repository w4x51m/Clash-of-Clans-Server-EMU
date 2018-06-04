namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.List;

    internal class ClanInvitationSentOk : Message
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanInvitationSentOk"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal ClanInvitationSentOk(Device Device) : base(Device)
        {
            this.Identifier = 24321;
        }
    }
}
