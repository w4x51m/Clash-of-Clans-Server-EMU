namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class JoinClan : Message
    {
        internal int HighID;
        internal int LowID;

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinClan"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public JoinClan(Device Device, Reader Reader) : base(Device, Reader)
        {
            // JoinClan.
        }

        internal override void Decode()
        {
            this.HighID = this.Reader.ReadInt32();
            this.LowID  = this.Reader.ReadInt32();
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            
        }
    }
}