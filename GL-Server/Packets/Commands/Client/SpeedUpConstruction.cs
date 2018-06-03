using System;
using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Logic.Components;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    internal class SpeedUpConstruction : Command
    {
        private int ID;

        public SpeedUpConstruction(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.ID = this.Reader.ReadInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            if (this.ID >= 500000000)
            {
                if (this.ID >= 504000000)
                {
                    if (this.ID >= 506000000)
                    {
                        if (this.ID >= 507000000)
                        {
                            new Out_Of_Sync(this.Device).Send();
                        }
                    }
                }
                else if (!this.Device.Player.Objects.Buildings[this.ID].SpeedUp())
                {
                    new Out_Of_Sync(this.Device).Send();
                }
            }
        }
    }
}
