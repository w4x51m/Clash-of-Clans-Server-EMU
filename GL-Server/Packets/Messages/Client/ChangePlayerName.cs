using System;
using System.Text.RegularExpressions;
using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Packets.Commands.Server;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Messages.Client
{
    using GL.Servers.CoC.Logic;

    using GL.Servers.Extensions.Binary;

    internal class ChangePlayerName : Message
    {
        private string Name;
        private byte State;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePlayerName"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Reader">The reader.</param>
        public ChangePlayerName(Device Device, Reader Reader) : base(Device, Reader)
        {
            // ChangeName.
        }

        /// <summary>
        /// Decodes this message.
        /// </summary>
        internal override void Decode()
        {
            this.Name  = this.Reader.ReadString();
            this.State = this.Reader.ReadByte();
        }

        /// <summary>
        /// Processes this message.
        /// </summary>
        internal override void Process()
        {
            if (this.Name != null)
            {
                this.Name = Regex.Replace(this.Name, @"\s+", " ");

                if (this.Name.Length >= 2)
                {
                    if (this.Name.Length <= 16)
                    {
                        this.Device.Player.Name = this.Name;
                        this.Device.Player.NameSetted = true;

                        new ServerCommand(this.Device, new ChangeName(this.Device, this.Name, this.State)).Send();

#if DEBUG
                        this.Device.Player.Resources.Plus(3000000, 1250000);
                        new ServerCommand(this.Device, new GemsAdded(this.Device, 1250000)).Send();
#endif   
                    }
                    else new PlayerNameChangeFailed(this.Device, PlayerNameChangeFailed.NameError.Badword).Send();
                }
                else
                {
                    new PlayerNameChangeFailed(this.Device, PlayerNameChangeFailed.NameError.Length).Send();
                }
            }
            else
            {
                new PlayerNameChangeFailed(this.Device, PlayerNameChangeFailed.NameError.Length).Send();
            }
        }
    }
}