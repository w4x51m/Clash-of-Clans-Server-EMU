namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Alliance_Levels : Data
    {
        public Alliance_Levels(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }
        public string Name { get; set; }
        public int ExpPoints { get; set; }
        public bool IsVisible { get; set; }
        public int TroopRequestCooldown { get; set; }
        public int TroopDonationLimit { get; set; }
        public int TroopDonationRefund { get; set; }
        public int TroopDonationUpgrade { get; set; }
        public int WarLootCapacityPercent { get; set; }
        public int WarLootMultiplierPercent { get; set; }
        public int BadgeLevel { get; set; }
        public string BannerSWF { get; set; }
    }
}
