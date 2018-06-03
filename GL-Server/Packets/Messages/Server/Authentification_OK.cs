namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;
    using GL.Servers.CoC.Logic.Enums;
    using GL.Servers.CoC.Logic.Slots.Items;
    using GL.Servers.Logic.Enums;

    internal class Authentification_OK : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Authentification_OK"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public Authentification_OK(Device Device) : base(Device)
        {
            this.Identifier     = 20104;
            this.Device.State   = State.LOGGED;
        }

        /// <summary>
        /// Encodes this message.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt(this.Device.Player.HighID);
            this.Data.AddInt(this.Device.Player.LowID);

            this.Data.AddInt(this.Device.Player.HighID);
            this.Data.AddInt(this.Device.Player.LowID);

            this.Data.AddString(this.Device.Player.Token);

            this.Data.AddString(this.Device.Player.Facebook.Identifier);
            this.Data.AddString(this.Device.Player.Gamecenter.Identifier);

            this.Data.AddInt((int) CVersion.Major);
            this.Data.AddInt((int) CVersion.Minor);
            this.Data.AddInt((int) CVersion.Revision);

            this.Data.AddString("prod");

            this.Data.AddInt(2); //Session Count
            this.Data.AddInt(3600); //Playtime Second
            this.Data.AddInt(0);

            this.Data.AddString(Facebook.ApplicationID);

            this.Data.AddString("1475268786112433"); // 14 75 26 87 86 11 24 33
            this.Data.AddString("1478039503100"); // 14 78 03 95 03 10 0

            this.Data.AddInt(0);
            this.Data.AddString(this.Device.Player.Google.Identifier);
            this.Data.AddString("FR");
            this.Data.AddString(null);
            this.Data.AddInt(1);

            this.Data.AddString("https://event-assets.clashofclans.com");
            this.Data.AddString("http://b46f744d64acd2191eda-3720c0374d47e9a0dd52be4d281c260f.r11.cf2.rackcdn.com/"); //Patch server?
            this.Data.AddString(null);
        }
    }
}