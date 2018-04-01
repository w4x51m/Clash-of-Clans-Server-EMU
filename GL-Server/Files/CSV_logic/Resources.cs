namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Resources : Data
    {
        public Resources(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string TID { get; set; }
        public string SWF { get; set; }
        public string CollectEffect { get; set; }
        public string ResourceIconExportName { get; set; }
        public string StealEffect { get; set; }
        public int StealLimitMid { get; set; }
        public string StealEffectMid { get; set; }
        public int StealLimitBig { get; set; }
        public string StealEffectBig { get; set; }
        public bool PremiumCurrency { get; set; }
        public string HudInstanceName { get; set; }
        public string CapFullTID { get; set; }
        public int TextRed { get; set; }
        public int TextGreen { get; set; }
        public int TextBlue { get; set; }
        public string WarRefResource { get; set; }
        public string BundleIconExportName { get; set; }
        public int VillageType { get; set; }
    }
}
