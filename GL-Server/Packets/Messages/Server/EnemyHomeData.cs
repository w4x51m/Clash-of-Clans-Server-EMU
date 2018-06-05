using GL.Servers.CoC.Core;

namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class EnemyHomeData : Message
    {
        private Player Enemy;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyHomeData"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public EnemyHomeData(Device Device, Player Enemy) : base(Device)
        {
            this.Identifier = 24107;
            this.Enemy      = Enemy;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt(0);
            this.Data.AddInt(-1);

            this.Data.AddInt(Resources.ServerTime);

            this.Data.AddRange(this.Enemy.Objects.ToBytes());
            this.Data.AddRange(this.Enemy.ToBytes);

            this.Data.AddRange(this.Device.Player.ToBytes);

            this.Data.AddInt(3);
            this.Data.AddInt(0);
            this.Data.Add(0);
        }
    }
}