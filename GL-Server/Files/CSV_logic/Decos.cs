namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;
    using GL.Servers.Files.CSV_Enums;

    internal class Decos : Data
    {
        public Decos(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string TID { get; set; }
        public string InfoTID { get; set; }
        public string SWF { get; set; }
        public string ExportName { get; set; }
        public string ExportNameConstruction { get; set; }
        public string BuildResource { get; set; }
        public int BuildCost { get; set; }
        public int RequiredExpLevel { get; set; }
        public int MaxCount { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Icon { get; set; }
        public int BaseGfx { get; set; }
        public string ExportNameBase { get; set; }
        public bool IsRed { get; set; }
        public bool NotInShop { get; set; }
        public int VillageType { get; set; }
        public int RedMul { get; set; }
        public int GreenMul { get; set; }
        public int BlueMul { get; set; }
        public int RedAdd { get; set; }
        public int GreenAdd { get; set; }
        public int BlueAdd { get; set; }
        public bool LightsOn { get; set; }
        public bool DecoPath { get; set; }

        public int GetBuildCost() => BuildCost;
        pubkic int GetMaxCount() => MaxCount;
        public int GetRequiredExpLevel() => RequiredExpLevel;

        public ResourceData GetBuildResource() => CSVManager.DataTables.GetResourceByName(BuildResource);

        public int GetSellPrice()
        {
            var calculation = (int) ((BuildCost * (long) 1717986919) >> 32);
            return (calculation >> 2) + (calculation >> 31);
        }
    }
}
