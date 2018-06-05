namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class PlayerNameChangeFailed : Message
    {
        private NameError Error;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerNameChangeFailed"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public PlayerNameChangeFailed(Device Device, NameError Error) : base(Device)
        {
            this.Identifier = 27002;
            this.Error      = Error;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt((int) this.Error);
        }

        internal enum NameError
        {
            Length,
            Badword
        }
    }
}