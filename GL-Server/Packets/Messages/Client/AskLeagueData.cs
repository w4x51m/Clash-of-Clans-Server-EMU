using GL.Servers.CoC.Core;
using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class AskLeagueData : Message
    {
        private int HighID;
        private int LowID;

        /// <summary>
        /// Initializes a new instance of the <see cref="AskLeagueData"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public AskLeagueData(Device Device, Reader Reader) : base(Device, Reader)
        {
            // AskClanData.
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