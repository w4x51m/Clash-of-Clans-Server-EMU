using GL.Servers.Extensions.List;

namespace GL.Servers.CoC.Packets.Commands.Server
{
    using GL.Servers.CoC.Logic;

    internal class GemsAdded : Command
    {
        private int Gems;
        private int Package;
        private int OfferID;

        private bool Gift;

        public GemsAdded(Device Device, int Gems, int Package = -1, int OfferID = -1, bool Gift = false) : base(Device)
        {
            this.Identifier = 7;

            this.Gems       = Gems;
            this.Package    = Package;
            this.OfferID    = OfferID;

            this.Gift       = Gift;
        }

        internal override void Encode()
        {
            this.Data.AddBool(this.Gift);
            this.Data.AddInt(this.Gems);
            this.Data.AddInt(this.Package);
            this.Data.AddInt(this.OfferID);
            this.Data.AddInt(this.Gift ? 1 : 0);
            this.Data.AddString(null);
        }
    }
}
