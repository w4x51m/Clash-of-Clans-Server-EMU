namespace GL.Servers.CoC.Files.CSV_Logic
{
    using GL.Servers.CoC.Files.CSV_Helpers;
    using GL.Servers.Files.CSV_Reader;

    internal class Locales : Data
    {
        public Locales(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Data.LoadData(this, this.GetType(), Row);
        }

        public string Name { get; set; }
        public string FileName { get; set; }
        public string LocalizedName { get; set; }
        public bool HasEvenSpaceCharacters { get; set; }
        public bool isRTL { get; set; }
        public string UsedSystemFont { get; set; }
        public string HelpshiftSDKLanguage { get; set; }
        public string HelpshiftSDKLanguageAndroid { get; set; }
        public int SortOrder { get; set; }
        public bool TestLanguage { get; set; }
        public string TestExcludes { get; set; }
        public bool BoomboxEnabled { get; set; }
        public string BoomboxUrl { get; set; }
        public string BoomboxStagingUrl { get; set; }
        public string HelpshiftLanguageTagOverride { get; set; }
        public string ForcedFontName { get; set; }
    }
}
