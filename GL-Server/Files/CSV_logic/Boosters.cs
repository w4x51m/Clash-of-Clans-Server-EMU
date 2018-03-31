namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Boosters : Data
    {
        public Boosters(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string TID { get; set; }
        public string InfoTID { get; set; }
        public string SWF { get; set; }
        public string ExportName { get; set; }
        public string IconSWF { get; set; }
        public string IconExportName { get; set; }
        public bool Enabled { get; set; }
        public int MaxItems { get; set; }
        public int DiamondValue { get; set; }
        public int DisplayOrder { get; set; }
        public bool FinishTroopUpgrade { get; set; }
        public bool FinishBuildingUpgrade { get; set; }
        public bool FinishSpellUpgrade { get; set; }
        public bool FinishHeroUpgrade { get; set; }
        public bool MaxLevelArmy { get; set; }
        public bool BoostResource { get; set; }
        public bool BoostProduction { get; set; }
        public string FillStorageResource { get; set; }
        public bool UpgradeWall { get; set; }
        public bool BoostBuilders { get; set; }
    }
}
