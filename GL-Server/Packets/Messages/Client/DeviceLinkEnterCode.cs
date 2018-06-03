namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class DeviceLinkEnterCode : Message
    {
        private string Code;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceLinkEnterCode"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public DeviceLinkEnterCode(Device Device, Reader Reader) : base(Device, Reader)
        {
            // DeliveLinkEnterCode.
        }

        internal override void Decode()
        {
            this.Code = this.Reader.ReadString();
        }
    }
}