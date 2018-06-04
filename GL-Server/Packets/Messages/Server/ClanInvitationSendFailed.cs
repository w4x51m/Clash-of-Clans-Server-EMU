namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.List;

    internal class ClanInvitationSendFailed : Message
    {
        private InvitationFailed Error;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanInvitationSendFailed"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal ClanInvitationSendFailed(Device Device, InvitationFailed Error) : base(Device)
        {
            this.Identifier = 24321;
        }

        internal override void Process()
        {
            this.Data.AddInt((int) this.Error);
        }
    }

    internal enum InvitationFailed
    {
        NoRight,
        NoCastle,
        AlreadyInClan,
        AlreadyHasAnInvite,
        ToManyInvite,
        UserBanned
    }
}
