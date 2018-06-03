using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Logic.Components;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    internal class UpgradeGameObject : Command
    {
        internal int ID;
        internal bool AltResource;

        public UpgradeGameObject(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.ID          = this.Reader.ReadInt32();
            this.AltResource = this.Reader.ReadBoolean();
            this.Tick        = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            if (this.ID >= 500000000)
            {
                if (this.ID >= 504000000)
                {
                    if (this.ID >= 506000000)
                    {
                        //new Out_Of_Sync(this.Device).Send();
                    }
                }
                else if (!this.Device.Player.Objects.Buildings[this.ID].Construct(this.AltResource))
                {
                    new Out_Of_Sync(this.Device).Send();
                }
            }
            else new Out_Of_Sync(this.Device).Send();
        }
    }
}
