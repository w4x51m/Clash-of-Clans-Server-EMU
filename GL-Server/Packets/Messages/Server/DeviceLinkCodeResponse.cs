namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class DeviceLinkCodeResponse : Message
    {
        private string Code;
        private int Expire;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceLinkCodeResponse"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public DeviceLinkCodeResponse(Device Device, string Code, int Expire) : base(Device)
        {
            this.Identifier = 26002;

            this.Code       = Code;
            this.Expire     = Expire;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddString(this.Code);
            
            this.Data.AddInt(0);
            this.Data.AddInt(this.Expire);
        }
    }
}