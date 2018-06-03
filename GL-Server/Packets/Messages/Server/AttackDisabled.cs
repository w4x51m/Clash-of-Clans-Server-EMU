namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class AttackDisabled : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttackDisabled"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public AttackDisabled(Device Device) : base(Device)
        {
            this.Identifier = 24121;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
        }
    }
}
