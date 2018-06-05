namespace GL.Servers.CoC.Packets.Messages.Server
{
    using GL.Servers.CoC.Logic;

    internal class Out_Of_Sync : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Out_Of_Sync"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        internal Out_Of_Sync(Device Device) : base(Device)
        {
            this.Identifier = 24104;
        }
    }
}