using GL.Servers.CoC.Core.Network;
using GL.Servers.CoC.Packets.Messages.Server;

namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    internal class ClaimAchievement : Command
    {
        internal int ID;

        public ClaimAchievement(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.ID   = this.Reader.ReadInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            if (!this.Device.Player.Progress.Claim(this.ID))
            {
                //this.Device.Player.Achievements.Add(this.ID);

                new Out_Of_Sync(this.Device).Send();
            }
        }
    }
}
