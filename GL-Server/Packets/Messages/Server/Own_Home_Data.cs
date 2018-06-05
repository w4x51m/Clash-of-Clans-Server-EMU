using System;
using GL.Servers.CoC.Core;

namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class Own_Home_Data : Message
    {
        private int Timestamp;

        /// <summary>
        /// Initializes a new instance of the <see cref="Own_Home_Data"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal Own_Home_Data(Device Device) : base(Device)
        {
            this.Identifier       = 24101;

            this.Timestamp        = Resources.ServerTime;

            this.Device.Player.Objects.Synchronize();
            this.Device.Player.Objects.Refresh((int) DateTime.UtcNow.Subtract(this.Device.Player.Objects.EndSession).TotalSeconds);
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt(0);
            this.Data.AddInt(-1);

            this.Data.AddInt(this.Timestamp);

            this.Data.AddRange(this.Device.Player.Objects.ToBytes());
            this.Data.AddRange(this.Device.Player.ToBytes);

            this.Data.AddInt(0);
            this.Data.AddInt(0);

            this.Data.AddInt(345);
            this.Data.AddInt(896691880);
            this.Data.AddInt(345);
            this.Data.AddInt(896691880);
            this.Data.AddInt(345);
            this.Data.AddInt(898491880);

            this.Data.AddInt(0);
        }

        internal override void Process()
        {
            this.Device.Tick      = 0;
            this.Device.Timestamp = this.Timestamp;
        }
    }
}