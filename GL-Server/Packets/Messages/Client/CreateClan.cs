using System;
using GL.Servers.CoC.Core;
using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class CreateClan : Message
    {
        private int HighID;
        private int LowID;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClan"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public CreateClan(Device Device, Reader Reader) : base(Device, Reader)
        {
            // CreateClan.
        }

        /// <summary>
        /// Decodes this message.
        /// </summary>
        internal override void Decode()
        {
            this.Debug();
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {

        }
    }
}