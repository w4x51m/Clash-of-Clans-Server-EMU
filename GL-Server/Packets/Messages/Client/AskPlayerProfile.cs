using System;
using GL.Servers.CoC.Core;
using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class AskPlayerProfile : Message
    {
        private int HighID;
        private int LowID;

        /// <summary>
        /// Initializes a new instance of the <see cref="AskPlayerProfile"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public AskPlayerProfile(Device Device, Reader Reader) : base(Device, Reader)
        {
            // AttackNpc.
        }

        /// <summary>
        /// Decodes this message.
        /// </summary>
        internal override void Decode()
        {
            this.Reader.ReadInt64();
            this.Reader.ReadByte();

            this.HighID = this.Reader.ReadInt32();
            this.LowID  = this.Reader.ReadInt32();
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            new PlayerProfile(this.Device)
            {
                HighID = this.HighID,
                LowID  = this.LowID

            }.Send();
        }
    }
}