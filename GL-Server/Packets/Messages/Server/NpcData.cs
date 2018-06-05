namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Core;
    using GL.Servers.CoC.Extensions.List;
    using GL.Servers.CoC.Logic;

    internal class NpcData : Message
    {
        private readonly int ID;

        private readonly Objects Objects;

        /// <summary>
        /// Initializes a new instance of the <see cref="NpcData"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal NpcData(Device Device, int ID, Objects Objects) : base(Device)
        {
            this.Identifier = 24133;
            this.ID         = ID;
            this.Objects    = Objects;
        }

        internal override void Encode()
        {
            this.Data.AddInt(0);

            this.Data.AddRange(this.Objects.ToBytes(true));
            this.Data.AddRange(this.Device.Player.ToBytes);

            this.Data.AddInt(this.ID);

            this.Data.AddByte(0);
        }

        internal override void Process()
        {
        }
    }
}
