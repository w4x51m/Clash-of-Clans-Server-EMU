namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class AttackHomeFailed : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttackHomeFailed"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public AttackHomeFailed(Device Device) : base(Device)
        {
            this.Identifier = 24106;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt(1);
        }
    }
}