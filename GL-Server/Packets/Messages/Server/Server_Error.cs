using System;

namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class Server_Error : Message
    {
        private string Error;

        /// <summary>
        /// Initializes a new instance of the <see cref="Server_Error"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Message">The message.</param>
        /// <param name="Initial">if set to <c>true</c> [initial].</param>
        public Server_Error(Device Device, string Error) : base(Device)
        {
            this.Identifier = 24115;
            this.Error      = Error;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddString(this.Error);
        }

        internal override void Process()
        {
            Console.WriteLine($"ServerError({this.Device.Player.HighID}-{this.Device.Player.LowID}) : {this.Error}");
        }
    }
}