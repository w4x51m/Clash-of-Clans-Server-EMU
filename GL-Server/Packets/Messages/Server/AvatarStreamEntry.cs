namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class AvatarStreamEntry : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvatarStreamEntry"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public AvatarStreamEntry(Device Device) : base(Device)
        {
            this.Identifier = 24412;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
        }
    }
}