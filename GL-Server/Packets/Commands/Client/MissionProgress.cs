namespace GL.Servers.CoC.Packets.Commands.Client
{
    using GL.Servers.CoC.Logic;
    using GL.Servers.Extensions.Binary;

    using GL.Servers.CoC.Files;
    using GL.Servers.CoC.Files.CSV_Logic;
    using GL.Servers.CoC.Logic.Enums;

    internal class MissionProgress : Command
    {
        private int ID;

        public MissionProgress(Reader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        internal override void Decode()
        {
            this.ID   = this.Reader.ReadInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            this.Device.Player.Missions.Add(this.ID, CSV.Tables.Get(Gamefile.Missions).GetDataWithID(this.ID) as Missions);
        }
    }
}
