namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;
    using GL.Servers.Logic.Enums;

    internal class Session_Key : Message
    {
        internal byte[] Key = new byte[16];

        /// <summary>
        /// Initializes a new instance of the <see cref="Session_Key"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        public Session_Key(Device Device) : base(Device)
        {
            this.Identifier = 20000;
            this.Device.Random.NextBytes(this.Key);
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt(this.Key.Length);
            this.Data.AddRange(this.Key);
            this.Data.AddInt(1);
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        internal override void Process()
        {
            this.Device.Crypto.UpdateCiphers(this.Device.CryptoSeed, this.Key);
            this.Device.State = State.LOGGED;
        }
    }
}