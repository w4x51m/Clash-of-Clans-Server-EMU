namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;
    using GL.Servers.Files;
    using GL.Servers.Logic.Enums;

    internal class Authentification_Failed : Message
    {
        internal string UpdateHost  = "https://www.gobelinland.fr/resources/gl-clash-of-clans.2/";
        internal string Message     = string.Empty;
        internal string ServerHost  = string.Empty;

        internal Reason Reason;

        /// <summary>
        /// Initializes a new instance of the <see cref="Authentification_Failed"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reason">The reason.</param>
        /// <param name="Message">The message.</param>
        public Authentification_Failed(Device Device, Reason Reason = Reason.Default, string Message = null, string ServerHost = "176.159.83.126") : base(Device)
        {
            this.Identifier     = 20103;
            this.Reason         = Reason;
            this.Message        = Message;
            this.ServerHost     = ServerHost;
            this.Version        = 9;
        }

        /// <summary>
        /// Gets the patching host.
        /// </summary>
        internal string PatchingHost
        {
            get
            {
                return Fingerprint.Custom ? "https://github.com/BerkanYildiz/GL.Patchs/tree/master/ClashOfClans/c6ef1bca4c99521ad85fe75fc6f8241c3b99b6a2/" : "http://b46f744d64acd2191eda-3720c0374d47e9a0dd52be4d281c260f.r11.cf2.rackcdn.com/";
            }
        }

        /// <summary>
        /// Encodes this message.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt((int) this.Reason);
            this.Data.AddString(null);
            this.Data.AddString(this.ServerHost);
            this.Data.AddString(this.PatchingHost);
            this.Data.AddString(this.Reason != Reason.Patch ? this.UpdateHost : null);
            this.Data.AddString(this.Message);
            this.Data.AddString(null);

            this.Data.AddCompressed(Fingerprint.Json);

            this.Data.AddString(null);
            this.Data.AddInt(2);
            this.Data.AddInt(0);
            this.Data.AddString(null);
            this.Data.AddString(null);
        }
    }
}