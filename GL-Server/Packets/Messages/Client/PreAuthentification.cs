namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Core;
    using GL.Servers.CoC.Core.Network;
    using GL.Servers.CoC.Logic;
    using GL.Servers.CoC.Logic.Enums;
    using GL.Servers.CoC.Packets.Messages.Server;

    using GL.Servers.Extensions.Binary;
    using GL.Servers.Files;
    using GL.Servers.Logic.Enums;

    internal class PreAuthentification : Message
    {
        internal int AppStore;
        internal int DeviceSO;
        internal int KeyVersion;
        internal int Protocol;
        internal int Major;
        internal int Minor;
        internal int Revision;

        internal string Hash;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreAuthentification"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public PreAuthentification(Device Device, Reader Reader) : base(Device, Reader)
        {
            this.Device.State = State.SESSION;
        }

        /// <summary>
        /// Decodes this message.
        /// </summary>
        internal override void Decode()
        {
            this.Protocol   = this.Reader.ReadInt32();
            this.KeyVersion = this.Reader.ReadInt32();
            this.Major      = this.Reader.ReadInt32();
            this.Revision   = this.Reader.ReadInt32();
            this.Minor      = this.Reader.ReadInt32();
            this.Hash       = this.Reader.ReadString();
            this.DeviceSO   = this.Reader.ReadInt32();
            this.AppStore   = this.Reader.ReadInt32();
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            if (this.Major == (int) CVersion.Major && this.Minor == (int) CVersion.Minor)
            {
                if (!Constants.Maintenance)
                {
                    if (string.Equals(this.Hash, Fingerprint.Sha))
                    {
                        new Authentification_Failed(this.Device, (Reason) 0, "Pepper cryptography not found!");
                    }
                    else
                    {
                        new Authentification_Failed(this.Device, Reason.Patch).Send();
                    }
                }
                else
                {
                    new Authentification_Failed(this.Device, Reason.Maintenance).Send();
                }
            }
            else
            {
                new Authentification_Failed(this.Device, Reason.Update).Send();
            }
        }
    }
}