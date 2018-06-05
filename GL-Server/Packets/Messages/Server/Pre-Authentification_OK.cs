namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    using GL.Servers.Core;
    using GL.Servers.Logic.Enums;

    internal class Pre_Authentification_OK : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pre_Authentification_OK"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal Pre_Authentification_OK(Device Device) : base(Device)
        {
            this.Identifier     = 20100;
            this.Device.State   = State.SESSION_OK;
        }

        /// <summary>
        /// Encodes the <see cref="Message" />, using the <see cref="Writer" /> instance.
        /// </summary>
        internal override void Encode()
        {
            this.Data.AddInt(24);
            this.Data.AddRange(Keys.Sodium.NonceKey);
        }
    }
}