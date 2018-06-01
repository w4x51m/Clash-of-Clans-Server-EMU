namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Leagues2 : Data
    {
        public Leagues2(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public int TrophyLimitLow { get; set; }
        public int TrophyLimitHigh { get; set; }
        public int GoldReward { get; set; }
        public int ElixirReward { get; set; }
        public int BonusGold { get; set; }
        public int BonusElixir { get; set; }
        public int SeasonTrophyReset { get; set; }
        public int MaxDiamondCost { get; set; }
    }
}
