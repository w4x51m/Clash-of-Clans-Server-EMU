using System;
using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Core;
    using GL.Servers.CoC.Files;
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class AttackNpc : Message
    {
        private int ID;

        private Objects Objects;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttackNpc"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public AttackNpc(Device Device, Reader Reader) : base(Device, Reader)
        {
            // AttackNpc.
        }

        /// <summary>
        /// Decodes this message.
        /// </summary>
        internal override void Decode()
        {
            this.ID = this.Reader.ReadInt32();
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            // This is trash and will be fixed later...
            //new NpcData(this.Device, this.ID, new Objects(this.Device.Player, NPC.Levels[this.ID])).Send();

            this.Device.Player.NpcProgress.Add(this.ID, 0);

            new Own_Home_Data(this.Device).Send();

            // Idk where I was going with this lol.
            //Resources.Battles.Start_NPC(this.Device.Player, this.ID, new Objects(this.Device.Player, NPC.Levels[this.ID]));
        }
    }
}