namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class PersonalBreakStarted : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalBreakStarted"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public PersonalBreakStarted(Device Device) : base(Device)
        {
            this.Identifier = 20171;
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