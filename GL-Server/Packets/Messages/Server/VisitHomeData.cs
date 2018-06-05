using GL.Servers.CoC.Core;

namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class VisitHomeData : Message
    {
        private Player Player;
        private int Map;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisitHomeData"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public VisitHomeData(Device Device, Player Player, int Map) : base(Device)
        {
            this.Identifier = 24113;
            this.Player     = Player;
            this.Map        = Map;

            this.Player.Progress.Synchronize();
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt(0); // this.Device.Player.OfflineTime
            this.Data.AddInt(-1);

            this.Data.AddInt(Resources.ServerTime);

            this.Data.AddInt(this.Device.Player.HighID);
            this.Data.AddInt(this.Device.Player.LowID);

            this.Data.AddRange(this.Player.Objects.ToBytes());
            this.Data.AddRange(this.Player.ToBytes);

            this.Data.AddInt(this.Map);

            this.Data.AddBool(true);
            this.Data.AddRange(this.Device.Player.ToBytes);
        }
    }
}