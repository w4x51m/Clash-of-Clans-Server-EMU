using GL.Servers.CoC.Extensions.Game;
using GL.Servers.Extensions.List;

namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Core;
    using GL.Servers.CoC.Logic;
    using GL.Servers.Library.ZLib;

    internal class PlayerProfile : Message
    {
        private Player Player;

        internal int HighID;

        internal int LowID;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerProfile"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal PlayerProfile(Device Device) : base(Device)
        {
            this.Identifier = 24334;
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        internal override void Encode()
        {
            //this.Player = this.HighID == this.Device.Player.HighID && this.LowID == this.Device.Player.LowID ? this.Device.Player : Resources.Players.Get(this.HighID, this.LowID);

            this.Data.AddRange(this.Device.Player.ToBytes);
            this.Data.AddCompressed(this.Device.Player.Objects.Serialize(), false);

            this.Data.AddInt(0);
            this.Data.AddInt(0);
            this.Data.AddInt(0);
            this.Data.AddInt(0);

            this.Data.Add(0);
        }
    }
}