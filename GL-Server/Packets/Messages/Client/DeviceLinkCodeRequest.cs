using System;
using GL.Servers.CoC.Core;
using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class DeviceLinkCodeRequest : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceLinkCodeRequest"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public DeviceLinkCodeRequest(Device Device, Reader Reader) : base(Device, Reader)
        {
            // DeviceLinkCodeRequest.
        }
    }
}