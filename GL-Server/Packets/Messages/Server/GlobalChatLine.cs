using GL.Servers.CoC.Core;

namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class GlobalChatLine : Message
    {
        private Player Sender;
        private string Message;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalChatLine"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public GlobalChatLine(Device Device, string Message, Player Sender) : base(Device)
        {
            this.Identifier = 24715;
            this.Sender     = Sender;
            this.Message    = Message;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddString(this.Message);

            this.Data.AddString(this.Sender.Name);

            this.Data.AddInt(this.Sender.Level);
            this.Data.AddInt(this.Sender.League);

            this.Data.AddInt(this.Sender.HighID);
            this.Data.AddInt(this.Sender.LowID);
            this.Data.AddInt(this.Sender.HighID);
            this.Data.AddInt(this.Sender.LowID);

            this.Data.AddBool(this.Sender.ClanLowID > 0);

            if (this.Sender.ClanLowID > 0)
            {
                Clan Clan = Resources.Clans.Get(this.Sender.ClanHighID, this.Sender.ClanLowID);

                if (Clan != null)
                {
                    this.Data.AddInt(Clan.HighID);
                    this.Data.AddInt(Clan.LowID);

                    this.Data.AddString(Clan.Name);

                    this.Data.AddInt(Clan.Badge);
                }
                else
                {
                    this.Data[this.Data.Count - 1] = 0;
                }
            }
        }
    }
}