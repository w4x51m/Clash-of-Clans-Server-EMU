using System;
using GL.Servers.CoC.Core;
using GL.Servers.CoC.Core.Network;

namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class ServerCommand : Message
    {
        private Command Command;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerCommand"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public ServerCommand(Device Device, Command Command) : base(Device)
        {
            this.Identifier = 24111;
            this.Command    = Command;

            this.Command.Encode();
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddRange(this.Command.ToBytes);
        }
    }
}