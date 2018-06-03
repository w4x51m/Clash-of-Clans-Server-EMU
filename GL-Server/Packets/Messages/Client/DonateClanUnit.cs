namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class DonateClanUnit : Message
    {
        private int UnitType;
        private int UnitID;

        private int RequestHighID;
        private int RequestLowID;

        private bool UnitBuyed;

        /// <summary>
        /// Initializes a new instance of the <see cref="DonateClanUnit"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public DonateClanUnit(Device Device, Reader Reader) : base(Device, Reader)
        {
            // DonateClanUnit.
        }

        internal override void Decode()
        {
            this.UnitType      = this.Reader.ReadInt32();
            this.UnitID        = this.Reader.ReadInt32();

            this.RequestHighID = this.Reader.ReadInt32();
            this.RequestLowID  = this.Reader.ReadInt32();

            this.UnitBuyed     = this.Reader.ReadBoolean();
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            // Process.
        }
    }
}