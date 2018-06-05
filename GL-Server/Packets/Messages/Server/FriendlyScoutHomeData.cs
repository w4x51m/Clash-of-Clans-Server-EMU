using GL.Servers.CoC.Core;
using GL.Servers.Extensions.List;

namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Logic;

    internal class FriendlyScoutHomeData : Message
    {
        private Player Player;

        private int HighID;
        private int LowID;

        private bool War;

        /// <summary>
        /// Initializes a new instance of the <see cref="FriendlyScoutHomeData"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal FriendlyScoutHomeData(Device Device, Player Player, int HighID, int LowID, bool War = false) : base(Device)
        {
            this.Identifier = 25007;

            this.Player     = Player;

            this.HighID     = HighID;
            this.LowID      = LowID;

            this.War        = War;
        }

        internal override void Encode()
        {
            this.Data.AddInt(Resources.ServerTime);

            this.Data.AddInt(this.Device.Player.HighID);
            this.Data.AddInt(this.Device.Player.LowID);

            this.Data.AddInt(this.Device.Player.HighID);
            this.Data.AddInt(this.Device.Player.LowID);

            this.Data.AddRange(this.Player.Objects.ToBytes());
            this.Data.AddInt(0); // 0:Default 1:War 2:War + people

            this.Data.AddBool(true);
            this.Data.AddRange(this.Device.Player.ToBytes);

            this.Data.AddInt(this.HighID);
            this.Data.AddInt(this.LowID);
        }
    }
}